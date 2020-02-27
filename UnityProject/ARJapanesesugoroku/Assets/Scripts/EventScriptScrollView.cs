using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScriptScrollView : MonoBehaviour
{
    [SerializeField] private GameObject eventScriptNode;
    [SerializeField] private GameObject content;
    [SerializeField] private InputField eventSetNameInputField;
    

    public void AddEventScriptNode()
    {
        Instantiate(eventScriptNode, content.transform);
    }

    public void SaveEventScriptNodes()
    {
        //EventScriptのリストを取得
        var nodes = content.GetComponentsInChildren<EventScriptNode>();
        //デバッグ用
        List<EventScripts> eventScripts = new List<EventScripts>();
        foreach(var node in nodes)
        {
            var eventScript = new EventScripts("", node.EventText, true, 10);
            eventScripts.Add(eventScript);
        }
        //eventScripts.Add(new EventScripts("","test1",true,10));
        //eventScripts.Add(new EventScripts("", "test2", true, 10));
        var eventSetName = eventSetNameInputField.text;

        //ここで保存関数を呼ぶ
        gameObject.GetComponent<EventSet>().WriteEventSet(eventSetName,eventScripts);
        Debug.Log("保存! " + eventSetName);
    }
}
