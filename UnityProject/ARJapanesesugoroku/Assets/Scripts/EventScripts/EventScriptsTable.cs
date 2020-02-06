using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="EventTable",fileName ="EventTable")]
public class EventScriptsTable : ScriptableObject
{
    //ここにUIに使うテキストリストを表示させる。
    public List<EventScripts> list = new List<EventScripts>();
}
