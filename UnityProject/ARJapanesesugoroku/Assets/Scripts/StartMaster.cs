using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartMaster : MonoBehaviourPunCallbacks
{
    public string SceneName;
    public GameObject obj_StartButton;
    public GameObject obj_NowLoading;
    // Start is called before the first frame update
    void Start()
    {
        obj_StartButton.SetActive(true);
        obj_NowLoading.SetActive(false);
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
        obj_StartButton.SetActive(false);
        obj_NowLoading.SetActive(true);
    }
}
