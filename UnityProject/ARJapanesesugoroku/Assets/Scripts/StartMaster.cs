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
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.PublishUserId = true;
        PhotonNetwork.JoinOrCreateRoom("room", roomOptions,TypedLobby.Default);
        
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("CreateRoom");
    }
}
