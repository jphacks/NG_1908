using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class　modoru : Masu
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
        manimator.SetInteger("large", 5);
        text.text = "1もどる";
        startbutton.gameObject.SetActive(false);
        endbutton.gameObject.SetActive(true);
    }
    public override void sukuend()
    {
        endbutton.gameObject.SetActive(false);
        text.text = "おつかれ!";
    }
}
