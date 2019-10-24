using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class tyuniill : Masu
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
    public override void sukustart()
    {
        manimator.SetInteger("large" ,1);
        text.text = "これから中二病になれ！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
    }
    public override void sukuend()
    {
        //endbutton.gameObject.SetActive(false);
        text.text = "おつかれ！";
    }
}
