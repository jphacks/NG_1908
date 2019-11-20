using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public static string PlayerName = "unknown";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName()
    {
        //入力画面のText(プレイヤーネーム)を会得
        Text inputName = GameObject.Find("InputField/Text").GetComponent<Text>();

        //Text型をstring型に変換
        PlayerName = inputName.text;

        Debug.Log(PlayerName);

    }

    //プレイヤーネームを他スクリプトで会得するため
    public static string getName()
    {
        return PlayerName;
    }
}
