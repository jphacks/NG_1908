using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEventMasu : EventMasu
{
    [SerializeField] string eventtxt;
    public TextMeshPro text;
    public override void RaiseEvent()
    {
        text.text = eventtxt;
    }

}
