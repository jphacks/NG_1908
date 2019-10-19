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
    public GameObject ThroughDiceButton;
    public GameObject JudgeUpnumber;
    public int updicenumber;
    private JugdeUpNumber judgeupnumber;
    private Vector3 saikoropos;
    private Quaternion saikororot;
    // Start is called before the first frame update
    void Start()
    {
        judgeupnumber = JudgeUpnumber.GetComponent<JugdeUpNumber>();
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
                Destroy(Saikoro);
                Destroy(Ground);
                Destroy(ThroughDiceButton);
                flag = false;
            }
        }
    }
    public void RollSaikoro()
    {
        Instantiate(Saikoro,new Vector3 (0,0,0),Quaternion.identity);
        Instantiate(Ground, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(ThroughDiceButton, new Vector3(0, 0, 0), Quaternion.identity);
        flag = true;
        
    }
}
