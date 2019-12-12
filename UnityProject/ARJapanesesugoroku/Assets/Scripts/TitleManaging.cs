using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManaging : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2, clowd1, clowd2,txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button2Activate()
    {
        button2.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);
        clowd2.gameObject.SetActive(false);
    }
}
