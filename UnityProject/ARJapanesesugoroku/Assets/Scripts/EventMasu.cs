using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMasu : MonoBehaviour
{
    //フラグ
    public bool Ready = false;
    public virtual void RaiseEvent()
    {
        Ready = true;
    }
    public virtual void EndProcess()
    {
        Ready = true;
    }

}
