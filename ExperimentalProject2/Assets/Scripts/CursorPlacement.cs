﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorPlacement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}