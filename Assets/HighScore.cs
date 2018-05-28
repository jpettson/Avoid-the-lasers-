﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public int score = 10;

	void Awake() {
		if (PlayerPrefs.HasKey("BombAvoiderHighScore")) {
			score = PlayerPrefs.GetInt("BombAvoiderHighScore");
		}
		PlayerPrefs.SetInt("BombAvoiderHighScore", score);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text gt = this.GetComponent<Text>();
		gt.text = "High Score: " + score;
		if (score > PlayerPrefs.GetInt("BombAvoiderHighScore")) {
			PlayerPrefs.SetInt("BombAvoiderHighScore", score);
		}
	}
}
