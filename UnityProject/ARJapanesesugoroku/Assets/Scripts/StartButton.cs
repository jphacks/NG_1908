using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartButton : MonoBehaviour
{
    //クリックしたらルームを制作or入る+シーンを移動
    public void OnClick()
    {
        PhotonNetwork.JoinOrCreateRoom("room",new RoomOptions(), TypedLobby.Default);
        SceneManager.LoadScene("MainScene");
    }
}
