using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GeneralTextScripts : EventMasu
{
    public EventScriptsTable eventScriptsTable;
    public TextMeshPro text;
    public Animator manimator;
    public override void RaiseEvent()
    {
        manimator.SetInteger("large", 1);
        var list =eventScriptsTable.list.Where(value => value.flag);
        int number= Random.Range(0, list.Count() - 1);
        Debug.Log(number);
        text.text = list.Skip(number).FirstOrDefault().eventText;
        Debug.Log(text.text);
        EndProcess();
    }
}
