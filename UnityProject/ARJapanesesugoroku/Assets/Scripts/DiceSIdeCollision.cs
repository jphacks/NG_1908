using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSIdeCollision : MonoBehaviour
{
    private float seconds = 0f;

    // Start is called before the first frame update
    void OnCollisionStay(Collision collision)
    {
        seconds += Time.deltaTime;
        if (seconds >= 1f)
        {
            Debug.Log("1"); 
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
