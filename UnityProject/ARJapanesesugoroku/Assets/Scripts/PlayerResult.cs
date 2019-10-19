using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResult : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    void Start()
    {
        string[] playername = new string[4];
        playername[0] = "1stplayer";
        playername[1] = "2ndplayer";
        playername[2] = "3rdplayer";
        playername[3] = "4thplayer";
        text.text = "1位   " + playername[0] + "\n2位   " + playername[1] + "\n3位   " + playername[2] + "\n4位   " + playername[3]; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
