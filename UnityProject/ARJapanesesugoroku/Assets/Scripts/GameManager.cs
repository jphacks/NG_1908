using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PhotonView m_photonView;
    public enum GameState { Idle,InitMapping,Mapping,WaitingOthers,InitGame,PlayingGame,RollingDice,MovingToSquere,Event,InitFinishGame,FinishGame}
    //現在状態の把握
    private GameState gameState = GameState.Idle;
    //プレイヤーのID
    public string PlayerID;
    
    //マッピングのクラス
    private Mapping mapping;
    //ゲームプレイ中のクラス
    private PlayerTurnMoving playerTurnMoving;

    // Start is called before the first frame update
    void Start()
    {
        m_photonView = GetComponent<PhotonView>();
        mapping = GetComponent<Mapping>();
        playerTurnMoving = GetComponent<PlayerTurnMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在のゲームの状態を把握
        switch (gameState)
        {
            case GameState.Idle:
                break;
            //マップ生成開始
            case GameState.InitMapping:
                if(PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
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
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    if (mapping.Ready==true)
                    {
                        m_photonView.RPC("RPCSetState", RpcTarget.All, GameState.WaitingOthers);
                    }
                
                }
                break;
            //全員初期位置移動
            case GameState.WaitingOthers:
                break;
            //ゲーム開始
            case GameState.InitGame:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    playerTurnMoving.InitGame();
                    
                }
                gameState = GameState.PlayingGame;
                break;
            //ゲーム中
            case GameState.PlayingGame:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにターンプレイヤーを変える
                    m_photonView.RPC("RPCState", RpcTarget.All, GameState.RollingDice);
                }
                break;
            case GameState.RollingDice:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにダイス振る処理入れる
                    m_photonView.RPC("RPCState", RpcTarget.All, GameState.MovingToSquere);
                }
                break;
            case GameState.MovingToSquere:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにマスを移動する処理を入れる
                    m_photonView.RPC("RPCState", RpcTarget.All, GameState.Event);
                }
                break;
            case GameState.Event:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    //ここにイベントせいぎょのしょりをいれる
                    //ここにターンプレイヤーがゴールにいるかどうか確認する
                    m_photonView.RPC("RPCState", RpcTarget.All, GameState.PlayingGame);
                }
                break;
            //ゲーム終了開始
            case GameState.InitFinishGame:
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
