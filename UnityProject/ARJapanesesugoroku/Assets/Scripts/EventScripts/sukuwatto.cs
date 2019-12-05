using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class sukuwatto : EventMasu
{
    public  TextMeshPro text;
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
            
            startTurn = 100000;
        }
    }
    
    public override void RaiseEvent()
    {
        manimator.SetInteger("large", 2);
        text.text = "10スクワットしろ！";
        //startbutton.gameObject.SetActive(false);
        //endbutton.gameObject.SetActive(true);
        EndProcess();
    }

}
