﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 30 * Time.deltaTime, 0f));// = new Vector3(0f, 3 * Time.deltaTime, 0f);
	}
}
