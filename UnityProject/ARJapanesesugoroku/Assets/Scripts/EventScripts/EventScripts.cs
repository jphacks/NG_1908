using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventScripts 
{
    //イベントの名前
    public string eventTextName;
    //イベントの内容
    public string eventText;
    //イベントのオンオフフラグ
    public bool flag;
   
    public EventScripts(string _eventTextName,string _eventText,bool _flag)
    {
        eventTextName = _eventTextName;
        eventText = _eventText;
        flag = _flag;
    }
}
