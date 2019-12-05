using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEventMasu : EventMasu
{
    public override void RaiseEvent()
    {
        EndProcess();
    }
    public virtual void TextEvent()
    {

    }
}
