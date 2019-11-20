using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecentName : MonoBehaviour
{
    string RcntName;

    public Text RcntNmText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RcntName = InputName.getName() + "\nとしてプレイ中"; 
        RcntNmText.text = RcntName;
    }
}
