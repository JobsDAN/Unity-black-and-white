﻿using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
