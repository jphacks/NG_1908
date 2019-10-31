using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyokiKaisiButton : MonoBehaviour
{
    public bool Ready = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Ready = true;
        PhotonNetwork.Destroy(gameObject);
    }
}
