using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

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
    //private JugdeUpNumber judgeupnumber;
    private FUJI_DiceRoll FUJI_diceRoll;
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
            if (FUJI_diceRoll.FUJI_DiceResult!=0)
            {
                updicenumber = FUJI_diceRoll.FUJI_DiceResult;
                StartCoroutine("DestroyDice");
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
        FUJI_diceRoll = MadeSaikoro.GetComponentInChildren<FUJI_DiceRoll>();
        /*Instantiate(Ground, new Vector3(0, -6, 0), Quaternion.identity);
        Instantiate(ThroughDiceButton, new Vector3(0, 0, 0), Quaternion.identity,RollCanvas.transform);*/
        flag = true;
        
    }
    IEnumerator  DestroyDice()
    {
        yield return new WaitForSeconds(3f);
        Ready = true;
        PhotonNetwork.Destroy(MadeSaikoro);
    }
}
