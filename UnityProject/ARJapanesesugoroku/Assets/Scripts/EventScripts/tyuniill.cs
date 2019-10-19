using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class tyuniill : MonoBehaviour
{
    public TextMeshPro text;
    public int large;
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
    public void tyunistart()
    {
        manimator.SetInteger("large" ,1);
        text.text = "これから中二病になれ！";
        startbutton.gameObject.SetActive(false);
        endbutton.gameObject.SetActive(true);
    }
    public void tyunisukuend()
    {
        endbutton.gameObject.SetActive(false);
        text.text = "おつかれ！";
    }
}
