using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomWindowLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Ins.ShowWindow("WelcomeWindow");
    }

}
