using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ChangeSceneToTitle : MonoBehaviour
{
    public void PushDown()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MattingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
}
