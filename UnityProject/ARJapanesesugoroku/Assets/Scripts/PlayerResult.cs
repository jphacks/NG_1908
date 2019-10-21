using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResult : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ResultFirst;
    void Start()
    {
        string Firstplayer = "player1";

        ResultFirst.text = Firstplayer;
    }

    public void winner()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
