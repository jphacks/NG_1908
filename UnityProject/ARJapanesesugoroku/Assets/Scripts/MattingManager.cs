using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MattingManager : MonoBehaviourPunCallbacks
{
    private PhotonView m_photonView;
    private bool flag = false;
    public Text InputText;
    //InputText
    public GameObject obj_InputText;
    //CreateRoomButton
    public GameObject obj_CreateroomButton;
    //JoinRoomButton
    public GameObject obj_JoinRoomButton;
    //GameStartButton
    public GameObject obj_GameStartButton;
    //CurrentRoomMember
    public GameObject obj_CurrentRoomMember;
    //MainScene
    public string mainSceneName;
    public GameObject obj_ordertext;
    public void Start()
    {
        //フラグの初期化
        flag = false;
         m_photonView = GetComponent<PhotonView>();
         //マスターサーバーに接続したらLobbyに入る
         PhotonNetwork.JoinLobby();
    }
    public void Update()
    {
        //フラグがtrueならシーン移動
        if (flag== true)
        {
            flag = false;
            SceneManager.LoadScene(mainSceneName);
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster2");
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        
    }

    //クリックしたら部屋を作る
    public void OnClickCreateRoom()
    {
        if (InputText.text == "")
        {
            Debug.LogError("textが空です");
            return;
        }
        string roomname = InputText.text;
        if (PhotonNetwork.InLobby)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.PublishUserId = true;
            PhotonNetwork.CreateRoom(roomname, roomOptions, TypedLobby.Default);
        }

    }
    public override void OnCreatedRoom()
    {

        Debug.Log("CreateRoom");
        obj_InputText.SetActive(false);
        obj_CreateroomButton.SetActive(false);
        obj_JoinRoomButton.SetActive(false);
        obj_CurrentRoomMember.SetActive(true);
        obj_GameStartButton.SetActive(true);
        Text ordertext = obj_ordertext.GetComponent<Text>();
        ordertext.text = "マッチング中・・・";
    }
    //クリックしたら部屋に入る
    public void OnClickJoinedRoom()
    {
        if (InputText.text == "")
        {
            Debug.LogError("textが空です");
            return;
        }
        string roomname = InputText.text;
        if (PhotonNetwork.InLobby)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.PublishUserId = true;
            PhotonNetwork.JoinRoom(roomname);
        }
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        obj_InputText.SetActive(false);
        obj_CreateroomButton.SetActive(false);
        obj_JoinRoomButton.SetActive(false);
        obj_CurrentRoomMember.SetActive(true);
        Text ordertext = obj_ordertext.GetComponent<Text>();
        ordertext.text = "マッチング中・・・";
    }
    //クリックしたらゲームスタート(フラグ起動)
    public void OnClickStartGame()
    {
        m_photonView.RPC("RPCStartGame", RpcTarget.All);
    }
    //フラグをオンにするRPC
    [PunRPC]
    public void RPCStartGame()
    {
        flag = true;
    }
}
