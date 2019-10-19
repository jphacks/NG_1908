using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameMaster : MonoBehaviourPunCallbacks ,IPunObservable
{
    
    private enum GameState { Idle,InitMapping,Mapping,WaitingOthers,InitGame,PlayingGame,RollingDice,MovingToSquere,Event,InitFinishGame,FinishGame}
    //現在状態の把握
    private GameState gameState = GameState.Idle;
    //プレイヤーのID
    public string PlayerID;

    //マッピングのクラス
    private Mapping mapping;

    // Start is called before the first frame update
    void Start()
    {
        mapping = GetComponent<Mapping>();    
    }

    // Update is called once per frame
    void Update()
    {
        //現在のゲームの状態を把握
        switch (gameState)
        {
            case GameState.Idle:
                break;
            case GameState.InitMapping:
                if(PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    mapping.CreateMapping();
                    gameState = GameState.Mapping;        
                }
                break;
            case GameState.Mapping:
                if (PlayerID == PhotonNetwork.LocalPlayer.UserId)
                {
                    if (mapping.Ready==true)
                    {

                    }
                    gameState = GameState.WaitingOthers;
                }
                break;
            case GameState.WaitingOthers:
                break;
            case GameState.InitGame:
                break;
            case GameState.PlayingGame:
                break;
            case GameState.InitFinishGame:
                break;
            case GameState.FinishGame:
                break;
        }
        
    }
    //自作変数の共有
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //送信側の処理
            stream.SendNext(PlayerID);
        }
        else
        {
            //受信側の処理
            PlayerID = (string)stream.ReceiveNext();
        }
    }
}
