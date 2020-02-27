using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EventSet : MonoBehaviour
{
    //EventSetの書き出し
    public void WriteEventSet(string eventSetName, List<EventScripts> eventNode)
    {

        //JsonFileへ書き出し
        string jsonFile = "";
        EventScriptsTable eventScriptsTable = new EventScriptsTable();
        eventScriptsTable.list = eventNode;
        jsonFile = JsonUtility.ToJson(eventScriptsTable);   
        Debug.Log(jsonFile);
        File.WriteAllText(Application.persistentDataPath+"\\"+eventSetName+".json",jsonFile);

    }
    //EventSetの読み込み
    public EventScriptsTable ReadEventSet(string fileName)
    {
        string json = File.ReadAllText(Application.persistentDataPath + "\\" + fileName + ".json");
        EventScriptsTable eventScriptsTable = JsonUtility.FromJson<EventScriptsTable>(json);
        return eventScriptsTable;
    }
}
