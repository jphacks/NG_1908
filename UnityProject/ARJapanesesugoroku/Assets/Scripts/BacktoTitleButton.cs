﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoTitleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TitleButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TitleButtonActivate()
    {
        TitleButton.gameObject.SetActive(true);
    }
}
