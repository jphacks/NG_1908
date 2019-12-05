using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class forbitEng : EventMasu
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
        manimator.SetInteger("large", 4);
        text.text = "ここから英語禁止！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
        EndProcess();
    }
}
