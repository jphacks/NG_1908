using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUJI_DiceRoll : MonoBehaviour
{
    public float FUJI_RandomChangeInterval = 1;
    private float FUJI_RandomCount = 0;
    private Rigidbody FUJI_DiceRB = null;
    private bool FUJI_ThrewDice = false;
    private float FUJI_RRV_X;
    private float FUJI_RRV_Y;
    private float FUJI_RRV_Z;
    // Start is called before the first frame update
    void Start()
    {
        FUJI_RRV_X = UnityEngine.Random.value * 1000;
        FUJI_RRV_Y = UnityEngine.Random.value * 1000;
        FUJI_RRV_Z = UnityEngine.Random.value * 1000;
        FUJI_DiceRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && FUJI_ThrewDice == false)
        {
            FUJI_RollDice();
            FUJI_RandomCount += 1 * Time.deltaTime;
            if(FUJI_RandomCount > FUJI_RandomChangeInterval)
            {
                FUJI_RRV_X = UnityEngine.Random.value * 1000;
                FUJI_RRV_Y = UnityEngine.Random.value * 1000;
                FUJI_RRV_Z = UnityEngine.Random.value * 1000;
                FUJI_RandomCount = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FUJI_ReleaseDice();
        }
    }
    public void FUJI_RollDice()
    {
        transform.Rotate(FUJI_RRV_X * Time.deltaTime,
                         FUJI_RRV_Y * Time.deltaTime,
                         FUJI_RRV_Z * Time.deltaTime);
    }
    public void FUJI_ReleaseDice()
    {
        Debug.Log("ReleaseDice");
    }
}
