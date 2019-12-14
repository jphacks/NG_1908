using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject saikoro;
    public void saikorogen()
    {
        StartCoroutine(DiceCoroutine());
    }
    IEnumerator DiceCoroutine()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(saikoro, new Vector3(Random.Range(-20.0f, 20.0f), 250.0f, 50.0f), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
