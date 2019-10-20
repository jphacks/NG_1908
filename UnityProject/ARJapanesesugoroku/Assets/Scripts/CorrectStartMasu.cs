using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectStartMasu : MonoBehaviour
{
    //監視用のフラグ
    [SerializeField]
    bool Ready = false;
    //Update動かす用のフラグ
    bool flag = false;
    public void Update()
    {
        if (flag == true)
        {
            
        }
    }
    public void WaitingAllPlayers()
    {
        flag = true;
    }
}
