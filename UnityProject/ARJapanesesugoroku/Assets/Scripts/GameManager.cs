﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

    public enum GameState { Idle,InitMapping,Mapping,InitWaitingOthers,WaitingOthers,InitGame,PlayingGame,InitRollingDice,RollingDice,InitMovingToSquere,MovingToSquere,InitEvent,Event,InitFinishGame,FinishGame}
public class GameManager : MonoBehaviourPunCallbacks
{
    //デバッグ用
    [SerializeField]
    public bool debugg = false;


    private PhotonView m_photonView;
    //現在状態の把握
    private GameState gameState = GameState.Idle;
    //プレイヤーのID
    public string PlayerID;
    //マスの管理リスト
    private GameObject[] MasuList;
    //プレイヤーリスト
    private string[] PlayerList;
    //ダイスの目
    private int dicenumber;
    //自分の現在マス(1オリジン)
    private int mynumber=0;
    //ネクストプレイヤーID
    private int nextplayerID;
    //ターン数
    public int turnnumber=0;
    //プレイヤーオブジェクト
    public GameObject Koma;
    //ARカメラオブジェクト
    public GameObject ARCamera;

    //初期の開始ボタン
    private SyokiKaisiButton syokiKaisiButton;
    //マッピングのクラス
    private Mapping mapping;
    //ゲームプレイ中のクラス
    private PlayerTurnMoving playerTurnMoving;
    //さいころを振るクラス
    private RollingSaikoro rollingSaikoro;
    //マス移動のクラス
    private MoveSelectedMasu moveSelectedMasu;
    //エンドシーンのクラス
    private EndingScript endingScript;
    //人をスタートに集めるマス
    private CorrectStartMasu correctStartMasu;
    //UIの表示クラス
    private TextMasterController textMasterController;

 
    // Start is called before the first frame update
    void Start()
    {
        m_photonView = GetComponent<PhotonView>();
        syokiKaisiButton = GetComponent<SyokiKaisiButton>();
        mapping = GetComponent<Mapping>();
        playerTurnMoving = GetComponent<PlayerTurnMoving>();
        rollingSaikoro = GetComponent<RollingSaikoro>();
        moveSelectedMasu = GetComponent<MoveSelectedMasu>();
        endingScript = GetComponent<EndingScript>();
        correctStartMasu = GetComponent<CorrectStartMasu>();
        textMasterController = GetComponent<TextMasterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在のゲームの状態を把握
        switch (gameState)
        {
            case GameState.Idle:
                if (PhotonNetwork.IsMasterClient)
                {
                    syokiKaisiButton.SetButton();
                    if (syokiKaisiButton.Ready)
                    {
                        m_photonView.RPC("RPCSetPlayerObject", RpcTarget.All);
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitMapping);
                    }
                    textMasterController.IndicateText(gameState, true);
                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
  
                break;
            //マップ生成開始
            case GameState.InitMapping:
                if (PhotonNetwork.IsMasterClient)
                {
                    Debug.Log("Initmapping");
                    mapping.CreateMapping();
                    gameState = GameState.Mapping;        
                }
                else
                {
                    mapping.WaitingMapping();
                    gameState = GameState.Mapping;
                    
                }
                break;
            //マップ生成中
            case GameState.Mapping:
                if (PhotonNetwork.IsMasterClient)
                {
                    textMasterController.IndicateText(gameState, true);
                    if (mapping.Ready==true)
                    {
                    
                        //マスを取得
                        MasuList = mapping.MasuList;
                        //これじゃダメだった 
                        //m_photonView.RPC("RPCSetMasuObject", RpcTarget.All,MasuList );
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.WaitingOthers);
                    }
                
                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
                break;

            case GameState.WaitingOthers:
                if (PhotonNetwork.IsMasterClient)
                {
                    textMasterController.IndicateText(gameState, true);
                    //全員初期位置移動
                    correctStartMasu.WaitingAllPlayers();
                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
                if (correctStartMasu.Ready == true)
                {
                    m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitGame);
                }
                break;
            //ゲーム開始
            case GameState.InitGame:
                if (PhotonNetwork.IsMasterClient)
                {
                    PlayerList = playerTurnMoving.InitGame();
                   /* Debug.Log(PlayerList);
                    Debug.Log(PlayerList.Length);
                    Debug.Log(PlayerList[1]);*/
                    m_photonView.RPC("RPCSetPlayerList",RpcTarget.All,PlayerList);
                }
                else
                {
                    //ここでマスタークライアント以外はマスリストを取得
                    MasuList = GameObject.FindGameObjectsWithTag("Masu");
                }
                gameState = GameState.PlayingGame;
                break;
            //ゲーム中
            case GameState.PlayingGame:
                //ターン数は1ターン目からスタート
                turnnumber += 1;
                if (PhotonNetwork.IsMasterClient)
                {
                    if (PlayerID == "")
                    {
                        photonView.RPC("RPCSetPlayerID", RpcTarget.All, PlayerList[0]);
                    }
                    else
                    {
                        int Playermember = PhotonNetwork.PlayerList.Length;
                        Debug.Log((PlayerID));
                        if (PlayerID == PlayerList[Playermember - 1])
                        {
                            nextplayerID = 0;
                            m_photonView.RPC("RPCSetPlayerID", RpcTarget.All, PlayerList[0]);
                        }
                        else
                        {
                            nextplayerID += 1;
                            m_photonView.RPC("RPCSetPlayerID", RpcTarget.All, PlayerList[nextplayerID]);
                        }
                    }
                    
                    //ここにターンプレイヤーを変える
                    m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitRollingDice);
                }

                break;
            case GameState.InitRollingDice:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    rollingSaikoro.RollSaikoro();
                }
                gameState = GameState.RollingDice;
                break;
            case GameState.RollingDice:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにダイス振る処理入れる
                    if (rollingSaikoro.Ready == true)
                    {
                        dicenumber = rollingSaikoro.updicenumber;
                        Debug.Log(dicenumber);
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitMovingToSquere);
                    }
                    textMasterController.IndicateText(gameState, true);
                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
                break;
            case GameState.InitMovingToSquere:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにマスを移動する処理を入れる
                    mynumber= moveSelectedMasu.MasuSelect(dicenumber,mynumber,MasuList);
                    MasuAppeal appeal = MasuList[mynumber - 1].GetComponent<MasuAppeal>();
                    if (appeal != null)
                    {
                        appeal.Appeal = true;
                    }

                    Debug.Log(mynumber);
                }
                m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.MovingToSquere);
                break;
            case GameState.MovingToSquere:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //次のステータスへ
                    if (moveSelectedMasu.Ready == true)
                    {
                       // moveSelectedMasu.Ready = false;
                        Debug.Log("youreached!!");
                        MasuAppeal appeal = MasuList[mynumber - 1].GetComponent<MasuAppeal>();
                        if (appeal != null)
                        {
                            appeal.PlayerCame = true;
                        }

                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitEvent);
                    }
                    textMasterController.IndicateText(gameState, true);

                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
                break;
            case GameState.InitEvent:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //イベントせいぎょのしょり
                    MasuList[mynumber-1].GetComponent<EventMasu>().RaiseEvent();
                }
                gameState = GameState.Event;
                break;
            case GameState.Event:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    Debug.Log(mynumber);
                    Debug.Log(MasuList.Length);
                    Debug.Log(mynumber == MasuList.Length);
                    if (MasuList[mynumber - 1].GetComponent<EventMasu>().Ready == true)
                    {
                        //ここにターンプレイヤーがゴールにいるかどうか確認する
                        if (mynumber == MasuList.Length)
                        {
                            //次のステータスへ
                            m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitFinishGame);
                        }
                        else
                        {
                            //繰り返し
                            m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.PlayingGame);
                        }
                    }
                    textMasterController.IndicateText(gameState, true);

                }
                else
                {
                    textMasterController.IndicateText(gameState, false);
                }
                break;
            //ゲーム終了開始
            case GameState.InitFinishGame:
                if (mynumber == MasuList.Length) endingScript.WinLoad();
                else endingScript.LoseLoad();
                break;
            //ゲーム終了処理中
            case GameState.FinishGame:
                break;
        }
        
    }

    [PunRPC]
    public void RPCSetState(GameState setState)
    {
        gameState = setState;
    }
    //ターンプレイヤーのIDを共有
    [PunRPC]
    public void RPCSetPlayerID(string setid)
    {
        PlayerID = setid;
    }
    //プレイヤーのリストを共有
    [PunRPC]
    public void RPCSetPlayerList(string[] setid)
    {
        PlayerList = setid;
    }
    [PunRPC]
    public void RPCSetPlayerObject()
    {
        string MyKomaname = Koma.name;
        GameObject MyKoma = PhotonNetwork.Instantiate(MyKomaname, new Vector3(0, 0, 0), Quaternion.identity);
        MyKoma.transform.parent = ARCamera.transform;
        MyKoma.transform.localPosition = Vector3.zero;
    }
    [PunRPC]
    public void RPCSetMasuObject(GameObject[] setMasuList)
    {
        MasuList = setMasuList;
    }
}
