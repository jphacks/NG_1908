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
       
    }


    public void OnClick()
    {
        //マスターサーバーに接続する
        PhotonNetwork.ConnectUsingSettings();
    }
}
