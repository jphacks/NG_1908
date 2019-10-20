using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CorrectStartMasu : MonoBehaviour
{
    //監視用のフラグ
    public bool Ready;
    //Update動かす用のフラグ
    bool flag = false;
    private Vector3[] objectdistance;
    public void Update()
    {
        if (flag == true)
        {
            objectdistance = new Vector3[PhotonNetwork.PlayerList.Length];
            Vector3 startposition = GameObject.FindWithTag("StartMasu").GetComponent<Transform>().position;
            GameObject[] objectList= GameObject.FindGameObjectsWithTag("Player");
            for (int i=0;i<objectList.Length;i++)
            {
                Vector3 objectposition = objectList[i].GetComponent<Transform>().position;
                objectdistance[i] = objectposition - startposition;
            }

            for (int i = 0; i < objectList.Length; i++)
            {
                if (objectdistance[i].magnitude>1.5)
                {
                        return;
                }
            }
            Ready = true;
            flag = false;
            
        }
    }
    public void WaitingAllPlayers()
    {
        flag = true;
    }
}
