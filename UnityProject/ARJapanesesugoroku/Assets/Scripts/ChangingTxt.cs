using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingTxt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;
    public void OnjoiningButtonClicked()
    {
        this.txt.text = "入りたい部屋のIDを入力してね";

    }
    public void OnCreateButtonClicked()
    {
        this.txt.text = "作りたい部屋のIDを入力してね";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
