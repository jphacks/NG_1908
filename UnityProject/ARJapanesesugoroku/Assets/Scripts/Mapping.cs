using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;

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
    //ホスト用の表示パネル
    public GameObject HostPaneru;
    //ゲスト用の表示パネル
    public GameObject GuestPanel;
    //スタートマス
    public GameObject StartMasu;
    //通常マス
    public GameObject[] Masus;
    //ゴールマス
    public GameObject GoalMasu;
    
    //ゴールマス生成用に一時的に記憶しておく
    private GameObject tmpMasu;
    //配置されたマスのリスト
    [SerializeField]
    public GameObject[] MasuList;
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
            
            int r = Random.Range(0, Masus.Length-1);
            GameObject Masu = Masus[r];
            if (distance.magnitude >= 1.5)
            {
                Quaternion rot = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                tmpMasu=PhotonNetwork.Instantiate(Masu.name, myposition + Vector3.down*1.1f, rot);
                tmpposition = myposition;
            }
        }
    }
    public void CreateMapping()
    {
        StartButton.SetActive(true);
        HostPaneru.SetActive(true);
    }
    public void WaitingMapping()
    {
        GuestPanel.SetActive(true);
    }
    //スタートボタンを押したらマップを作り始める
    public void OnClickStartButton()
    {
        tmpposition =MyKoma.GetComponent<Transform>().position;
        StartButton.SetActive(false);
        EndButton.SetActive(true);
        //スタートマスを置く
        PhotonNetwork.Instantiate(StartMasu.name,tmpposition + Vector3.down*1.1f,Quaternion.identity);
        creatingflag = true;
    }
    //エンドボタンを押したらマップを作り終わる
    public void OnClickEndButton()
    {
        if (tmpMasu.transform.position!=null)
        {
            tmpposition = tmpMasu.transform.position;
            Destroy(tmpMasu);
            PhotonNetwork.Instantiate(GoalMasu.name, tmpposition, Quaternion.identity);
            MasuList = GameObject.FindGameObjectsWithTag("Masu");
            Debug.Log(string.Join(", ", MasuList.Select(obj => obj.ToString())));
            EndButton.SetActive(false);
            creatingflag = false;
            Ready = true;
        }

    }
}
