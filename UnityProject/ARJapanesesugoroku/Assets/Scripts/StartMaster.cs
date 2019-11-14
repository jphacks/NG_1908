using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartMaster : MonoBehaviourPunCallbacks
{
    public string SceneName;  
    // Start is called before the first frame update
    void Start()
    {

    }


    public  override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        
        SceneManager.LoadScene(SceneName);
        //マスターサーバーに接続したらLobbyに入る
        //PhotonNetwork.JoinLobby();
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
    public void OnClick()
    {
        //マスターサーバーに接続する
        PhotonNetwork.ConnectUsingSettings();
        
    }
}
