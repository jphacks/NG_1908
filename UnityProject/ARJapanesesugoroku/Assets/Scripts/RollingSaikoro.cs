using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RollingSaikoro : MonoBehaviour
{
    //Stateのフラグ
    [SerializeField]
    public bool Ready = false;
    //アップデートを動かすフラグ
    public bool flag;
    public GameObject SaikoroKit;
    public GameObject MadeSaikoro;
    /*public GameObject Ground;
    public GameObject ThroughDiceButton;
    public GameObject RollCanvas;*/
    public int updicenumber;
    private JugdeUpNumber judgeupnumber;
    private Vector3 saikoropos;
    private Quaternion saikororot;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ready = false;
        if (flag == true)
        {           
            if (judgeupnumber.UpDiceNumber!=0)
            {
                updicenumber = judgeupnumber.UpDiceNumber;
                Ready = true;
                Destroy(MadeSaikoro);
                /*Destroy(Ground);
                Destroy(ThroughDiceButton);*/
                flag = false;
            }
        }
    }
    public void RollSaikoro()
    {
        Quaternion rot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        MadeSaikoro = PhotonNetwork.Instantiate(SaikoroKit.name,Camera.main.transform.position, rot);
        judgeupnumber = MadeSaikoro.GetComponentInChildren<JugdeUpNumber>();
        /*Instantiate(Ground, new Vector3(0, -6, 0), Quaternion.identity);
        Instantiate(ThroughDiceButton, new Vector3(0, 0, 0), Quaternion.identity,RollCanvas.transform);*/
        flag = true;
        
    }
}
