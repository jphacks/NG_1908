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
            TextMaster textMaster = list.Find(m => m.gameState == gameState);
            UItext.text = textMaster != null ? textMaster.mainText : "";
        }
        else
        {
            //Othersテキストの表示
            TextMaster textMaster = list.Find(m => m.gameState == gameState);
            UItext.text = textMaster != null ? textMaster.othersText : "";
        }
    }

}
