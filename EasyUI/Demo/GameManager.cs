﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    void Start () {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Main Scene");
    }

}
