using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onbutton1clicked()
    {
        GetComponent<Animator>().SetInteger("button1clicking", 1);
        Debug.Log("押された");
    }
    public void Onbutton2clicked()
    {
        GetComponent<Animator>().SetInteger("button2clicking", 1);
        Debug.Log("押された!");
    }
    public void Onanimeationanding()
    {
       //ここにシーン遷移
    }
}
