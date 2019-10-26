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
            //全プレイヤーのリスト
            List<GameObject> allobjectList = null;
            //以下オブジェクトをFindして全体リストへ追加
            GameObject[] playerobjectArray= GameObject.FindGameObjectsWithTag("Player");
            allobjectList.AddRange(playerobjectArray);
            GameObject[] otehrsobjectArray= GameObject.FindGameObjectsWithTag("Others");
            allobjectList.AddRange(otehrsobjectArray);
            //全プレイヤーリストを配列に変換
            GameObject[] allobjectArray = allobjectList.ToArray();
            for (int i=0;i<allobjectArray.Length;i++)
            {
                Vector3 objectposition = allobjectArray[i].GetComponent<Transform>().position;
                objectdistance[i] = objectposition - startposition;
            }

            for (int i = 0; i < allobjectArray.Length; i++)
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
