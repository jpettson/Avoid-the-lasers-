using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel("_scene_0");
		} else if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
