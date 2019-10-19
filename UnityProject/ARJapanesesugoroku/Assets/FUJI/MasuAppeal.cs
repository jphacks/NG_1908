using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuAppeal : MonoBehaviour
{
    public bool Appeal = false;
    public bool PlayerCame = false;
    private MeshRenderer Frame = null;
    public float Speed;
    public float StartScaleXZ;
    private Vector3 StartScale = Vector3.zero;
    private float Interval = 0.1f;
    private float time = 0;
    private int PlusMinus = 1;
    private int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Frame = transform.Find("MasuAppealFrame").gameObject.GetComponent<MeshRenderer>();
        StartScale = new Vector3(StartScaleXZ, 1, StartScaleXZ);
    }

    // Update is called once per frame
    void Update()
    {
        if(Appeal == true)
        {
            transform.localScale += new Vector3(Speed,0,Speed) * Time.deltaTime;
            if(transform.localScale.x <= 0.18f) {
                transform.localScale = StartScale;
            }
        }
        if(PlayerCame == true)
        {
            Appeal = false;
            transform.localScale = new Vector3(0.18f,1,0.18f);
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
    }
