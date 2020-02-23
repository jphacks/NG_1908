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
//        var nodes = content.GetComponentsInChildren<EventScripts>();

        var eventSetName = eventSetNameInputField.text;

        //ここで保存関数を呼ぶ
        Debug.Log("保存! " + eventSetName);
    }
}
