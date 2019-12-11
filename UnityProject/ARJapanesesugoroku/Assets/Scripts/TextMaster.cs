using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TextMaster 
{
    //stateとMainプレイヤー、それ以外のプレイヤーに表示するテキスト
    public string state="";
    public string mainText="";
    public string othersText="";

    public TextMaster(string state, string mainText, string othersText)
    {
        state = this.state;
        mainText = this.mainText;
        othersText = this.othersText;
    }

}
