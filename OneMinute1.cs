using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMinute1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, -6f * Time.deltaTime, 0f);
    }
}
