using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuAppeal : MonoBehaviour
{
    public bool Appeal = false;
    public float Speed;
    public float StartScaleXZ;
    private Vector3 StartScale = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
