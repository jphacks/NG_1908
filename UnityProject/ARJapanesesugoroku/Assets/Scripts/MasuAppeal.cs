using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuAppeal : MonoBehaviour
{
    [SerializeField]
    private Transform Cloud = null;
    private Material CloudPs;
    public bool Appeal = false;
    public bool PlayerCame = false;
    private MeshRenderer WaitingText = null;
    private MeshRenderer OKText = null;
    private float red, green, blue, alpha;
    public float Speed = 0;
    private int PlusMinus = 1;

    // Start is called before the first frame update
    void Start()
    {
        WaitingText = transform.Find("WaitingForPlayer").gameObject.GetComponent<MeshRenderer>();
        OKText = transform.Find("OK").gameObject.GetComponent<MeshRenderer>();
//        Cloud = this.transform.GetChild(4);
        CloudPs = Cloud.gameObject.GetComponent<ParticleSystemRenderer>().material;
        red = CloudPs.color.r;
        green = CloudPs.color.g;
        blue = CloudPs.color.b;
        alpha = CloudPs.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha >= 0.9)
        {
            if (PlusMinus == 1)
            {
                PlusMinus *= -1;
            }
        }
        else if (alpha <= 0)
        {
            if (PlusMinus == -1)
            {
                PlusMinus *= -1;
            }
        }
        if (Appeal == true)
        {
            WaitingText.enabled = true;
            CloudPs.color = new Color(red, green, blue, alpha);
            alpha += Speed * PlusMinus * Time.deltaTime;
        }
        if (PlayerCame == true)
        {
            Invoke("PCfalse", 1);
            WaitingText.enabled = false;
            OKText.enabled = true;
            Appeal = false;
        }
    }
    void PCfalse()
    {
        PlayerCame = false;
        OKText.enabled = false;
    }
}
