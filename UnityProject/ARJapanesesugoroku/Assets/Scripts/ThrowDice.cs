﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDice : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void PushUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
        rb.AddForce( Camera.main.transform.rotation * new Vector3(0,150,1000));
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
