using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dance : EventMasu
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
        manimator.SetInteger("large", 6);
        text.text = "ミライ小町と踊ろう！！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
        EndProcess();
    }
}
