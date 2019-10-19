using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject countdowner;
    public GameObject Goalbutton;
    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoalButtonclicked()
    {
        countdowner.gameObject.SetActive(true);
        Goalbutton.gameObject.SetActive(false);
        text.text = "スタート位置についてね";

    }
}
