using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectStartMasu : MonoBehaviour
{
    //監視用のフラグ
    [SerializeField]
    public bool Ready = false;
    //Update動かす用のフラグ
    bool flag = false;
    public void Update()
    {
        if (flag == true)
        {
            Vector3 startposition = GameObject.FindWithTag("StartMasu").GetComponent<Transform>().position;
            Vector3 myposition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
            Vector3 distance = myposition - startposition;
            if (distance.magnitude <= 1.5)
            {
                Ready = true;
                flag = false;
            }
        }
    }
    public void WaitingAllPlayers()
    {
        flag = true;
    }
}
