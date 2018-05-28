using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomber : MonoBehaviour {

	public GameObject bombPrefab;

	public float speed = 20f;

	public float leftAndRightEdge = 19f;

	public float chanceToChangeDirections = 0.02f;

	public float secondsBetweenBombDrops = 0.2f;

	public Text scoreGT;

	public int score = 0;

	// Use this for initialization
	void Start () {
		//Fropping bombs every second
		InvokeRepeating("DropBomb", 2f, secondsBetweenBombDrops);

		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text>();
		scoreGT.text = "Score: " + score;

		InvokeRepeating("SetScore", 2f, secondsBetweenBombDrops);
	}

	void SetScore() {
		//int score = int.Parse(scoreGT.text);
		score = score+=1;
		if (score > HighScore.score) {
			HighScore.score = score;
		}
		scoreGT.text = "Score: " + score.ToString();
	}

	void DropBomb() {
		GameObject bomb = Instantiate(bombPrefab) as GameObject;
//		bomb.transform.position = transform.position;
		bomb.transform.position = new Vector3(transform.position.x, transform.position.y-1, 1);
		//bomb.transform.position = bombPos;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed*Time.deltaTime;
		transform.position = pos;

		if (pos.x <- leftAndRightEdge) {
			speed = Mathf.Abs(speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs(speed);
		}
	}

	void FixedUpdate() {
		if (Random.value < chanceToChangeDirections) {
		speed *= -1;
		}
	}
}
