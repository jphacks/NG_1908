using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerTagStatus : MonoBehaviourPunCallbacks
{
    PhotonView m_photonView;
    // Start is called before the first frame update
    void Awake()
    {
        m_photonView= GetComponent<PhotonView>();
        Debug.Log(m_photonView.IsMine);
        if (m_photonView.IsMine)
        {

            gameObject.tag = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
