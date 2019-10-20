using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class yasumi : Masu
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
        manimator.SetInteger("large", 3);
        text.text = "1回やすみ";
        startbutton.gameObject.SetActive(false);
        endbutton.gameObject.SetActive(true);
    }
    public override void sukuend()
    {
        endbutton.gameObject.SetActive(false);
        text.text = "おつかれ!";
    }
}
