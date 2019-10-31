﻿using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerTurnMoving : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public string [] InitGame()
    {
        Player[] allplayers = PhotonNetwork.PlayerList;
        string[] allplayersID = new string[allplayers.Length];

        /*for (int i=0; i<allplayers.Length; i++)
        {
            allplayersID[i] = PhotonNetwork.PlayerList[i].UserId;
        }*/

        Debug.Log(allplayers[0].UserId);
        Debug.Log(allplayers[1].UserId);
        Debug.Log(PhotonNetwork.PlayerList[1].UserId);
        Debug.Log(PhotonNetwork.PlayerListOthers[0].UserId);

        //プレイヤーリストをシャッフル
        for (int i = 0; i < allplayers.Length; i++)
        {
            Player tmp = allplayers[i];
            int playernumber = Random.Range(i, allplayers.Length-1);
            allplayers[i] = allplayers[playernumber];
            allplayers[playernumber] = tmp;
        }
        Debug.Log(allplayers[0].UserId);
        Debug.Log(allplayers[1].UserId);

        for (int i = 0; i < PhotonNetwork.CurrentRoom.Players.Count; i++)
        {
            allplayersID[i] = allplayers[i].UserId;
        }
        Debug.Log(allplayers.Length);

        return allplayersID;
    }
}
