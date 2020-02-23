using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScriptNode : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    
    //テスト用
    private string _eventText;
    
    public void SetEventText()
    {
        //本来はEventScriptsクラスにInputFieldの値を代入

        _eventText = inputField.text;
    }

    public void DeleteNode()
    {
        Destroy(gameObject);
    }
}
