using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuAppeal : MonoBehaviour
{
    public bool Appeal = false;
    public bool PlayerCame = false;
    private GameObject FrameParent = null;
    private MeshRenderer Frame = null;
    private MeshRenderer WaitingText = null;
    private MeshRenderer OKText = null;
    public float Speed = -0.15f;
    public float StartScaleXZ = 0.3f;
    public float Limit;
    private Vector3 StartScale = Vector3.zero;
    private float Interval = 0.1f;
    private float time = 0;
    private int PlusMinus = 1;
    private int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        FrameParent = transform.Find("MasuAppealFrame").gameObject;
        Frame = transform.Find("MasuAppealFrame/MasuAppealFrameChild").gameObject.GetComponent<MeshRenderer>();
        WaitingText = transform.Find("WaitingForPlayer").gameObject.GetComponent<MeshRenderer>();
        OKText = transform.Find("OK").gameObject.GetComponent<MeshRenderer>();
        StartScale = new Vector3(StartScaleXZ, 1, StartScaleXZ);
    }

    // Update is called once per frame
    void Update()
    {
        if(Appeal == true)
        {
            Count = 0;
            time = 0;
            WaitingText.enabled = true;
            Frame.enabled = true;
            FrameParent.transform.localScale += new Vector3(Speed,0,Speed) * Time.deltaTime;
            if(FrameParent.transform.localScale.x <= Limit) {
                FrameParent.transform.localScale = StartScale;
            }
        }
        if(PlayerCame == true)
        {
            Invoke("PCfalse", 1);
            WaitingText.enabled = false;
            OKText.enabled = true;
            Appeal = false;
            FrameParent.transform.localScale = new Vector3(1,1,1);
            time += PlusMinus*Time.deltaTime;
            if (time > Interval)
            {
                Frame.enabled = false;
                PlusMinus *= -1;
            }
            if(time < 0 && Count <=3)
            {
                Frame.enabled = true;
                PlusMinus *= -1;
                Count++;
            }
            }
        }
    void PCfalse()
    {
        PlayerCame = false;
        OKText.enabled = false;
        Frame.enabled = false;
    }
    }
