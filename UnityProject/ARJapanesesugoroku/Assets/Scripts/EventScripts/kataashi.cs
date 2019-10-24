﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class kataashi : Masu
{
    public TextMeshPro text;
    public GameObject startbutton;
    public GameObject endbutton;
    public Animator manimator;

    public int startTurn = 100000;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.turnnumber - startTurn == 4)
        {
            sukuend();
            startTurn = 100000;
        }
    }
    public override void sukustart()
    {
        manimator.SetInteger("large", 7);
        text.text = "1ターン片足立ち！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
        startTurn = gameManager.turnnumber;
    }
    public override void sukuend()
    {
        //endbutton.gameObject.SetActive(false);
        text.text = "おつかれ!";
    }
}
