using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    //デバッグ用
    [SerializeField]
    public bool debugg = false;


    private PhotonView m_photonView;
    public enum GameState { Idle,InitMapping,Mapping,WaitingOthers,InitGame,PlayingGame,InitRollingDice,RollingDice,InitMovingToSquere,MovingToSquere,InitEvent,Event,InitFinishGame,FinishGame}
    //現在状態の把握
    private GameState gameState = GameState.Idle;
    //プレイヤーのID
    public string PlayerID;
    //マスの管理リスト
    private GameObject[] MasuList;
    //ダイスの目
    private int dicenumber;
    //自分の現在マス
    private int mynumber=0;
    
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


    // Start is called before the first frame update
    void Start()
    {
        m_photonView = GetComponent<PhotonView>();
        mapping = GetComponent<Mapping>();
        playerTurnMoving = GetComponent<PlayerTurnMoving>();
        rollingSaikoro = GetComponent<RollingSaikoro>();
        moveSelectedMasu = GetComponent<MoveSelectedMasu>();
        endingScript = GetComponent<EndingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在のゲームの状態を把握
        switch (gameState)
        {
            case GameState.Idle:
                if (debugg == true)
                {
                    gameState = GameState.InitMapping;
                }
                break;
            //マップ生成開始
            case GameState.InitMapping:
                //デバッグ用aaaaaaaaaaaa
                PlayerID = PhotonNetwork.LocalPlayer.UserId;
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
                    if (mapping.Ready==true)
                    {
                    
                        //マスを取得
                        MasuList = mapping.MasuList;
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.WaitingOthers);
                    }
                
                }
                break;
            //全員初期位置移動
            case GameState.WaitingOthers:
                m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitGame);
                break;
            //ゲーム開始
            case GameState.InitGame:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //playerTurnMoving.InitGame();
                    
                }
                gameState = GameState.PlayingGame;
                break;
            //ゲーム中
            case GameState.PlayingGame:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
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
                 
                }
                break;
            case GameState.InitMovingToSquere:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにマスを移動する処理を入れる
                    mynumber= moveSelectedMasu.MasuSelect(dicenumber,mynumber,MasuList);
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
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.InitEvent);
                    }

                }
                break;
            case GameState.InitEvent:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにイベントせいぎょのしょりをいれる
                }
                gameState = GameState.Event;
                break;
            case GameState.Event:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    Debug.Log(mynumber);
                    Debug.Log(MasuList.Length);
                    Debug.Log(mynumber == MasuList.Length);
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
                break;
            //ゲーム終了開始
            case GameState.InitFinishGame:
                endingScript.EndLoad();
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


}
