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
    //確率の重み
    public int weight;
   
    public EventScripts(string _eventTextName,string _eventText,bool _flag,int _weight)
    {
        eventTextName = _eventTextName;
        eventText = _eventText;
        flag = _flag;
        weight = _weight;
    }
}
