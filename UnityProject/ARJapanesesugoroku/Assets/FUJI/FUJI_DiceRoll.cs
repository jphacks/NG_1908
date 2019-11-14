using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUJI_DiceRoll : MonoBehaviour
{
    public GameObject PlayerCamera_Dice = null;
    public float FUJI_RandomChangeInterval = 1;
    private float FUJI_RandomCount = 0;
    public float FUJI_DiceCheckInterval = 1;
    private float FUJI_DiceCheckCount = 0;
    private Rigidbody FUJI_DiceRB = null;
    private bool FUJI_ThrewDice = false;
    private float FUJI_RRV_X;
    private float FUJI_RRV_Y;
    private float FUJI_RRV_Z;
    private Vector3 FUJI_Dice_OldPosition;
    private Vector3 FUJI_Dice_NewPosition;

    // Start is called before the first frame update
    void Start()
    {
        FUJI_Dice_OldPosition = transform.position;
        PlayerCamera_Dice = GameObject.Find("Main Camera");
        FUJI_RRV_X = UnityEngine.Random.Range(0.5f, 1) * 1000;
        FUJI_RRV_Y = UnityEngine.Random.Range(0.5f, 1) * 1000;
        FUJI_RRV_Z = UnityEngine.Random.Range(0.5f, 1) * 1000;
        FUJI_DiceRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FUJI_ThrewDice == true)
        {
            FUJI_DiceCheckCount += 1 * Time.deltaTime;
            if (FUJI_DiceCheckCount > FUJI_DiceCheckInterval)
            {
                FUJI_DiceCheckCount = 0;
                FUJI_DiceCheck();
            }
        }
        if (Input.GetKey(KeyCode.Space) && FUJI_ThrewDice == false)
        {
            FUJI_RollDice();
            FUJI_RandomCount += 1 * Time.deltaTime;
            if(FUJI_RandomCount > FUJI_RandomChangeInterval)
            {
                FUJI_RRV_X = UnityEngine.Random.Range(0.5f, 1) * 1000;
                FUJI_RRV_Y = UnityEngine.Random.Range(0.5f, 1) * 1000;
                FUJI_RRV_Z = UnityEngine.Random.Range(0.5f, 1) * 1000;
                FUJI_RandomCount = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (FUJI_ThrewDice == false)
            {
                FUJI_ThrewDice = true;
                FUJI_ReleaseDice();
            }
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
        FUJI_DiceRB.useGravity = true;
        FUJI_DiceRB.AddForce(PlayerCamera_Dice.transform.forward * 1000);
    }
    void FUJI_DiceCheck()
    {
        //古い位置と新しい位置とを格納し、その距離が0.1未満なら止まったと判定。
        FUJI_Dice_OldPosition = FUJI_Dice_NewPosition;
        FUJI_Dice_NewPosition = transform.position;
        if ((FUJI_Dice_NewPosition - FUJI_Dice_OldPosition).magnitude < 0.1)
        {
            //上の目が何か判定　TransformDirection
            Vector3 FUJI_Check16 = transform.TransformDirection(Vector3.up);
            Vector3 FUJI_Check25 = transform.TransformDirection(Vector3.forward);
            Vector3 FUJI_Check43 = transform.TransformDirection(Vector3.right);
            if(Mathf.Round(FUJI_Check16.y) == 1)
            {
                Debug.Log(1);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(Mathf.Round(FUJI_Check16.y) == -1)
            {
                Debug.Log(6);
                transform.GetChild(6).gameObject.SetActive(true);
            }
            else if (Mathf.Round(FUJI_Check25.y) == 1)
            {
                Debug.Log(2);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (Mathf.Round(FUJI_Check25.y) == -1)
            {
                Debug.Log(5);
                transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (Mathf.Round(FUJI_Check43.y) == 1)
            {
                Debug.Log(4);
                transform.GetChild(4).gameObject.SetActive(true);
            }
            else if (Mathf.Round(FUJI_Check43.y) == -1)
            {
                Debug.Log(3);
                transform.GetChild(3).gameObject.SetActive(true);
            }
        }

    }
}
