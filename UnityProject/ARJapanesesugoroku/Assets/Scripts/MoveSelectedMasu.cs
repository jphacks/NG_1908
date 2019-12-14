using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedMasu : MonoBehaviour
{
    //監視用のフラグ
    public bool Ready = false;
    //マップ移動中かどうかのフラグ
    private bool flag = false;
    //自機
    private GameObject MyKoma;
    //目標のマス
    private GameObject TargetMasu;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            Ready = false;
            if (TargetMasu!=null)
            {
                //ターゲットのマスとの距離計算
                Vector3 targetvector = TargetMasu.transform.position;
                Vector3 MyKomaVector = MyKoma.transform.position;
                Vector3 targetdistance = MyKomaVector - targetvector;
                //Debug.Log(targetdistance.magnitude);
                //ターゲットマスとの距離が一定以下ならマスにのsったと判定
                if (targetdistance.magnitude <= 1.1f)
                {
                    //ここにマス目の効果付けの削除を描く

                    flag = false;
                    Ready = true;
                }
            }

        }
    }
    public int MasuSelect(int dicenumber, int mynumber,GameObject[]Masulist)
    {
        MyKoma = GameObject.FindWithTag("Player");
        mynumber += dicenumber;
        if (mynumber >= Masulist.Length)
        {
            mynumber = Masulist.Length;
        }
        //ここにマス目に効果をつけるところの処理を追加する
        TargetMasu = Masulist[mynumber-1];
        flag = true;
        return mynumber;
    }
}
