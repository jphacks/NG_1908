﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdowning : MonoBehaviour
{
    public Text timerText;

    public float totalTime = 30;
    int seconds;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTime  -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();

    }
}
