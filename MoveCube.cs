using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
    //    transform.position = new Vector3(10f, 10f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, 1f * Time.deltaTime);
	}
}
