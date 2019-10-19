using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour
{
    //監視用のフラグ
    [SerializeField]
    public bool Ready;
    //マップ制作中かどうかのフラグ
    private bool creatingflag = false;
    //自分のコマ
    private GameObject MyKoma;
    //自分の位置
    private Vector3 tmpposition;
    //スタートボタン
    public GameObject StartButton;
    //ゴールボタン
    public GameObject EndButton;
    //スタートマス
    public GameObject StartMasu;
    //通常マス
    public GameObject Masu;
    //ゴールマス
    public GameObject GoalMasu;
    //ゴールマス生成用に一時的に記憶しておく
    private GameObject tmpMasu;
    // Start is called before the first frame update
    void Start()
    {
        Ready = false;
        MyKoma = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingflag==true)
        {
            Vector3 myposition = MyKoma.GetComponent<Transform>().position;
            Vector3 distance = myposition - tmpposition;
            if (distance.magnitude >= 1.5)
            {
                tmpMasu=Instantiate(Masu, myposition, Quaternion.identity);
                tmpposition = myposition;
            }
        }
    }
    public void CreateMapping()
    {
        StartButton.SetActive(true);
    }
    //スタートボタンを押したらマップを作り始める
    public void OnClickStartButton()
    {
        tmpposition =MyKoma.GetComponent<Transform>().position;
        StartButton.SetActive(false);
        EndButton.SetActive(true);
        //スタートマスを置く
        Instantiate(StartMasu,tmpposition,Quaternion.identity);
        creatingflag = true;
    }
    //エンドボタンを押したらマップを作り終わる
    public void OnClickEndButton()
    {
        if (tmpMasu.transform.position!=null)
        {
            tmpposition = tmpMasu.transform.position;
            Destroy(tmpMasu);
            Instantiate(GoalMasu, tmpposition, Quaternion.identity);
            creatingflag = false;
            Ready = true;
        }

    }
}
