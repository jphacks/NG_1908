using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Rotator : MonoBehaviourPunCallbacks
{
    private PhotonView m_photonView;
    public bool pushr = false;
    // Start is called before the first frame update
    void Start()
    {
        m_photonView = GetComponent<PhotonView>();
    }
    public void PushDown()
    {
        if (!m_photonView.IsMine)
        {
            return;
        }
        pushr = true;
    }

    public void Pushup()
    {
        if (!m_photonView.IsMine)
        {
            return;
        }
        pushr = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (pushr)
        {
            int x, y, z;
            x = Random.Range(800, 1000);
            y = Random.Range(200, 500);
            z = Random.Range(200, 500);
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
        }
    }
}
