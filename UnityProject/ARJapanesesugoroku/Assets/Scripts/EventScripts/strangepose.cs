﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class strangepose : EventMasu
{
    public TextMeshPro text;
    public GameObject startbutton;
    public GameObject endbutton;
    public Animator manimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void RaiseEvent()
    {
        manimator.SetInteger("large", 3);
        text.text = "1ターン変なポーズ！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
        EndProcess();
    }
}
