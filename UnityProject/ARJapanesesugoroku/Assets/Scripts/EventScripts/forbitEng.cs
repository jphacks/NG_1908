using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class forbitEng : Masu
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
        manimator.SetInteger("large", 4);
        text.text = "ここから英語禁止！";
        startbutton.gameObject.SetActive(false);
        endbutton.gameObject.SetActive(true);
    }
    public override void sukuend()
    {
        endbutton.gameObject.SetActive(false);
        text.text = "おつかれ!";
    }
}
