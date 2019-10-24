using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThrowDice : MonoBehaviour
{
    private PhotonView m_photonView;
    public Rigidbody rb;
    void Start()
    {
        m_photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }
    public void PushUp()
    {
        if (!m_photonView.IsMine)
        {
            return;
        }
        GetComponent<Rigidbody>().useGravity = true;
        rb.AddForce( Camera.main.transform.rotation * new Vector3(0,150,1000));
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
