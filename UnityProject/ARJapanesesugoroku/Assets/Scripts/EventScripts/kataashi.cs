﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class kataashi : MonoBehaviour
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
    public void sukustart()
    {
        manimator.SetInteger("large", 7);
        text.text = "1ターン片足立ち！";
        startbutton.gameObject.SetActive(false);
        endbutton.gameObject.SetActive(true);
    }
    public void sukuend()
    {
        endbutton.gameObject.SetActive(false);
        text.text = "おつかれ!";
    }
}
