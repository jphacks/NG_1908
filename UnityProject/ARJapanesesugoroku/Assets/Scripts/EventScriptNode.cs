using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScriptNode : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    
    private string _eventText;
    public string EventText
    {
        get => _eventText;
    }
    
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
