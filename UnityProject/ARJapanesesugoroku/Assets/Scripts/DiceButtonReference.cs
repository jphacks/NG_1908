using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DiceButtonReference : MonoBehaviour
{
    //GameManager周り
    private GameObject obj_GameManager;
    public string gameManagerTag;
    // Start is called before the first frame update
    void Start()
    {
        obj_GameManager = GameObject.FindWithTag(gameManagerTag);
    }

    // Update is called once per frame
    void Update()
    {
        string userID = obj_GameManager.GetComponent<GameManager>().PlayerID;
        if (userID!=PhotonNetwork.LocalPlayer.UserId)
        {
            gameObject.SetActive(false);
        }
    }
}
