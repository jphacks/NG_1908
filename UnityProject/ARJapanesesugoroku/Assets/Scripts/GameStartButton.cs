﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    //クリックしたらゲームスタート
    public void OnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
