﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSecond : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, -360f * Time.deltaTime);
	}
}
