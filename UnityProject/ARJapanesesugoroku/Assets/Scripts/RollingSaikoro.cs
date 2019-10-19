using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSaikoro : MonoBehaviour
{
    //Stateのフラグ
    [SerializeField]
    public bool Ready = false;
    //アップデートを動かすフラグ
    public bool flag;
    public GameObject Saikoro;
    public GameObject Ground;
    public GameObject TroughDiceButton;
    public GameObject JudgeUpnumber;
    public int updicenumber;
    private JugdeUpNumber judgeupnumber;
    private Vector3 saikoropos;
    private Quaternion saikororot;
    // Start is called before the first frame update
    void Start()
    {
        judgeupnumber = JudgeUpnumber.GetComponent<JugdeUpNumber>();
        saikoropos= Saikoro.transform.position;
        saikororot = Saikoro.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Ready = false;
        if (flag == true)
        {           
            if (judgeupnumber.flag == true)
            {
                updicenumber = judgeupnumber.UpDiceNumber;
                Ready = true;
                Saikoro.GetComponent<Rigidbody>().useGravity = false;
                Saikoro.SetActive(false);
                Ground.SetActive(false);
                TroughDiceButton.SetActive(false);
                flag = false;
            }
        }
    }
    public void RollSaikoro()
    {
        Debug.Log(judgeupnumber.UpDiceNumber);
        Saikoro.SetActive(true);
        Ground.SetActive(true);
        Saikoro.transform.position = saikoropos;
        Saikoro.transform.rotation = saikororot;
        TroughDiceButton.SetActive(true);
        flag = true;
        Ready = false;
    }
}
