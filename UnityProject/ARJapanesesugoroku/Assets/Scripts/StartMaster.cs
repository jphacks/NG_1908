using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class StartMaster : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Photonに接続するところまで実装
    /// </summary>
    public GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        //マスターサーバーに接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    public  override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        //マスターサーバーに接続したらLobbyに入る
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        //Lobbyに入ったらボタンを起動
        StartButton.SetActive(true);
    }
}
