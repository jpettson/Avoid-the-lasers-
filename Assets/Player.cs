using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	int lifesLeft = 0;
	public float leftAndRightEdge = 19f;
	public float upEdge = 4f;
	public float DownEdge = -14f;

	public Text invincybilityGT;
	public float invincibilityTimer;

	public GameObject shieldPrefab;
	public static GameObject tShieldGO;

	// Use this for initialization
	void Start () {
		lifesLeft = 3;
		invincibilityTimer = 1;
		GameObject invincibilityGO = GameObject.Find("InvincibilityText");
		invincybilityGT = invincibilityGO.GetComponent<Text>();
		invincybilityGT.text = "Press Spacebar for 5 sec invincibility";
		//setAndPrintLife(lifesLeft);
	}

	public void startShield(float x, float y) {
		tShieldGO = Instantiate(shieldPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.y = y;
		pos.x = x;
		tShieldGO.transform.position = pos;
		//return tShieldGO;
	}

	IEnumerator ExecuteAfterTime() {
		yield return new WaitForSeconds(5);
		BombAvoider.invincibility = 0;
		invincybilityGT.text = "";
		destroyShield();
		//Destroy(tShieldGO);
		yield return new WaitForSeconds(20);
		invincybilityGT.text = "Press Spacebar for 5 sec invincibility";
		invincibilityTimer = 1;
		print("invincibilityTimer = " + invincibilityTimer);
	}

	public static void destroyShield() {
			Destroy(tShieldGO);
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		if (Input.GetKey(KeyCode.LeftArrow) && position.x >- leftAndRightEdge) {
			position.x = position.x - 0.5f;
			this.transform.position = position;
			tShieldGO.transform.position = position;
		} else if (Input.GetKey(KeyCode.RightArrow) && position.x < leftAndRightEdge) {
			position.x = position.x + 0.5f;
			this.transform.position = position;
			tShieldGO.transform.position = position;
		} else if (Input.GetKey(KeyCode.UpArrow) && position.y < upEdge) {
			position.y = position.y + 0.5f;
			this.transform.position = position;
			tShieldGO.transform.position = position;
		} else if (Input.GetKey(KeyCode.DownArrow) && position.y > DownEdge) {
			position.y = position.y - 0.5f;
			this.transform.position = position;
			tShieldGO.transform.position = position;
		} else if (Input.GetKeyDown(KeyCode.Space) && invincibilityTimer == 1) {
			print("Ok");
			//invincybilityGT.text = "You are now invincible!";
			invincybilityGT.text = "";
			startShield(position.x, position.y);
			BombAvoider.invincibility = 1;
			invincibilityTimer = 0;
			StartCoroutine("ExecuteAfterTime");
		}
	}

	//Stuff w/ collition detection
	void OnCollisionEnter(Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "bomb" && BombAvoider.invincibility == 0) {
			lifesLeft -= 1;
			if (lifesLeft == 0) {
				Application.LoadLevel("_scene_2");
			}
			Destroy(collidedWith);
			BombAvoider apScript = Camera.main.GetComponent<BombAvoider>();
			apScript.BombDestroyed();
			int lifeSlistIndex = BombAvoider.lifesList.Count-1;
			GameObject tPlayerLifeGO = BombAvoider.lifesList[lifeSlistIndex];
			BombAvoider.lifesList.RemoveAt(lifeSlistIndex);
			Destroy(tPlayerLifeGO);
		}
	} 
}
