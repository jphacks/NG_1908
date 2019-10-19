using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdowning : MonoBehaviour
{
    public Text timerText;

    public float totalTime;
    int seconds;
    //フラグ
    bool flag = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag ==  true)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            timerText.text = seconds.ToString();
        }


    }
    public void OnClickEnd()
    {
        flag = true;
    }
}
