using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MttingButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joiningbutton;
    public GameObject creatingbutton;
    public GameObject inputform;
    public GameObject roomjoin;
    public GameObject roomcreate;
    public GameObject obj_ordertext;
    public void OnjoiningButtonClicked()
    {
        Text ordertext = obj_ordertext.GetComponent<Text>();
        ordertext.text = "入りたい部屋の名前を入力してね";
        joiningbutton.gameObject.SetActive(false);
        creatingbutton.gameObject.SetActive(false);
        roomjoin.gameObject.SetActive(true);
        inputform.gameObject.SetActive(true);

    }
    public void OnCreateButtonClicked()
    {
        Text ordertext = obj_ordertext.GetComponent<Text>();
        ordertext.text = "作成したい部屋の名前を入力してね";
        joiningbutton.gameObject.SetActive(false);
        creatingbutton.gameObject.SetActive(false);
        roomcreate.gameObject.SetActive(true);
        inputform.gameObject.SetActive(true);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
