using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CalcurateMatchingNumbers : MonoBehaviour
{
    public Text playernumbertext;
    private int playernumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playernumber = PhotonNetwork.PlayerList.Length;
        playernumbertext.text = "マッチング人数 " + playernumber + "人";
    }
}
