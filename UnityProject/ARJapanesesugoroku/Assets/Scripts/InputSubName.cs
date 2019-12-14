using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSubName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //タイトルに戻る際にプレイヤーネームが登録されているかの確認
    public void GetSubName()
    {
        //入力画面のText(プレイヤーネーム)を会得
        Text inputSubName = GameObject.Find("InputField/Text").GetComponent<Text>();

        //Text型をstring型に変換
        string PlayerSubName = inputSubName.text;

        Debug.Log(PlayerSubName);

        string PlayerName = InputName.getName();

        if (PlayerSubName != PlayerName)
        {

        }

    }
}
