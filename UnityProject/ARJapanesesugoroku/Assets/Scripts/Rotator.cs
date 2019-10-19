using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool pushr = false;
    public void PushDown()
    {
        pushr = true;
    }

    public void Pushup()
    {
        pushr = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
