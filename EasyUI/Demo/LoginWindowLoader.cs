using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginWindowLoader : MonoBehaviour {

    private void Awake()
    {
        UIManager.Ins.ShowWindow("GameWindow");
    }
}
