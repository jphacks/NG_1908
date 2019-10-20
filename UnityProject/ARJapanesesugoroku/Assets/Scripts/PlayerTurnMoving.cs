using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerTurnMoving : MonoBehaviourPunCallbacks
{
    Player []allplayers;
    string[] allplayersID;
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
        allplayers = PhotonNetwork.PlayerList;
        //プレイヤーリストをシャッフル
        for (int i = 0; i < allplayers.Length; i++)
        {
            Player tmp = allplayers[i];
            int playernumber = Random.Range(i, allplayers.Length);
            allplayers[i] = allplayers[playernumber];
            allplayers[playernumber] = tmp;
        }
        for (int i = 0; i < allplayers.Length; i++)
        {
            allplayersID[i] = allplayers[i].UserId;
        }
        return allplayersID;
    }
}
