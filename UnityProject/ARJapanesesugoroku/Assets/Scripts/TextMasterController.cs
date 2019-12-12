using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMasterController : MonoBehaviour
{
    public Text UItext;
    //ここにUIに使うテキストリストを表示させる。
    public List<TextMaster> list = new List<TextMaster>();
    //テキストの表示
    public void IndicateText(GameState gameState,bool main)
    {
        if (main == true)
        {
            //Mainテキストの表示
            UItext.text = list.Find(m => m.gameState == gameState).mainText;
        }
        else
        {
            //Othersテキストの表示
            UItext.text = list.Find(m => m.gameState == gameState).othersText;
        }
    }

}
