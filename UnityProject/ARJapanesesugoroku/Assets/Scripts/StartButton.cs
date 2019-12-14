using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartButton : MonoBehaviour
{
    //クリックしたらシーンを移動
    public void OnClick()
    {
        SceneManager.LoadScene("WaitScene");
    }
}
