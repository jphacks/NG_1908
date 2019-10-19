using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugdeUpNumber : MonoBehaviour
{
    //上面のサイコロの目
     public int UpDiceNumber=0;
    //投げた後かどうかの判定用
    bool throwing = false;

    //サイコロの中心と各側面のｙ座標
    float centery, y1, y2, y3, y4, y5, y6;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void PushUp()
    {
        throwing = true;
    } 
    // Update is called once per frame
    void Update()
    {
      
        //ｙ座標代入
        Vector3 tmpDice = GameObject.Find("Dice").transform.position;
        centery = tmpDice.y;
        Vector3 tmpSide1 = GameObject.Find("Collision1").transform.position;
        y1 = tmpSide1.y;
        Vector3 tmpSide2 = GameObject.Find("Collision2").transform.position;
        y2 = tmpSide2.y;
        Vector3 tmpSide3 = GameObject.Find("Collision3").transform.position;
        y3 = tmpSide3.y;
        Vector3 tmpSide4 = GameObject.Find("Collision4").transform.position;
        y4 = tmpSide4.y;
        Vector3 tmpSide5 = GameObject.Find("Collision5").transform.position;
        y5 = tmpSide5.y;
        Vector3 tmpSide6 = GameObject.Find("Collision6").transform.position;
        y6 = tmpSide6.y;

        //中心と側面のy座標の差が1.7-1.9であればその側面が上面、３秒後にもう一度判定
        if (throwing)
        {
            if (y1 - centery >= 1.7 && y1 - centery <= 1.9)
            {
                Invoke("DiceUp1", 3);
                
            }
            if (y2 - centery >= 1.7 && y2 - centery <= 1.9)
            {
                Invoke("DiceUp2", 3);
                
            }
            if (y3 - centery >= 1.7 && y3 - centery <= 1.9)
            {
                Invoke("DiceUp3", 3);
                
            }
            if (y4 - centery >= 1.7 && y4 - centery <= 1.9)
            {
                Invoke("DiceUp4", 3);
                
            }
            if (y5 - centery >= 1.7 && y5 - centery <= 1.9)
            {
                Invoke("DiceUp5", 3);
                
            }
            if (y6 - centery >= 1.7 && y6 - centery <= 1.9)
            {
                Invoke("DiceUp6", 3);
                
            }



        }


    }
    
    //以下３秒後の判定、投げた判定throwingを元に戻す
    void DiceUp1()
    {
        if (y1 - centery >= 1.7 && y1 - centery <= 1.9)
        {
            //Debug.Log("１が上です！");
            UpDiceNumber = 1;       
            throwing = false;
        }

    }
    void DiceUp2()
    {
        if (y2 - centery >= 1.7 && y2 - centery <= 1.9)
        {
            //Debug.Log("2が上です！");
            UpDiceNumber = 2;    
            throwing = false;
        }
        

    }
    void DiceUp3()
    {
        if (y3 - centery >= 1.7 && y3 - centery <= 1.9)
        {
            //Debug.Log("3が上です！");
            UpDiceNumber = 3;          
            throwing = false;
        }
        

    }
    void DiceUp4()
    {
        if (y4 - centery >= 1.7 && y4 - centery <= 1.9)
        {
            //Debug.Log("4が上です！");
            UpDiceNumber = 4;        
            throwing = false;
        }
        

    }
    void DiceUp5()
    {
        if (y5 - centery >= 1.7 && y5 - centery <= 1.9)
        {
            //Debug.Log("5が上です！");
            UpDiceNumber = 5;
            throwing = false;
        }
        

    }
    void DiceUp6()
    {
        if (y6 - centery >= 1.7 && y6 - centery <= 1.9)
        {
            //Debug.Log("6が上です！");
            UpDiceNumber = 6;
            throwing = false;
        }
      

    }

}
