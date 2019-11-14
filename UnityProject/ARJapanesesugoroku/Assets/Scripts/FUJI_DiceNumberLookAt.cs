using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUJI_DiceNumberLookAt : MonoBehaviour
{
    private GameObject Camera = null;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.transform.position);
    }
}
