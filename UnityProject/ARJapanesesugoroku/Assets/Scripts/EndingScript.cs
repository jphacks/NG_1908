using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndLoad()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void WinLoad()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseLoad()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
