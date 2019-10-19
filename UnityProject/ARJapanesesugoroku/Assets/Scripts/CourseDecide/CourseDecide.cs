using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourseDecide : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject goalbutton;
    public GameObject startbutton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButtonclicked()
    {
        text.text = "コースにしたいところを歩こう ゴール地点でボタンを押してね";
        goalbutton.gameObject.SetActive(true);
        startbutton.gameObject.SetActive(false);
    }
}
