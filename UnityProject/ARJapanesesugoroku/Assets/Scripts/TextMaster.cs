using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class TextMaster 
{
    //stateとMainプレイヤー、それ以外のプレイヤーに表示するテキスト
    public GameState gameState;
    public string mainText="";
    public string othersText="";

    public TextMaster(GameState state, string mainText, string othersText)
    {
        state = this.gameState;
        mainText = this.mainText;
        othersText = this.othersText;
    }

}
