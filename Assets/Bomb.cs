using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public static float bottomY = -20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy(this.gameObject);
		}
		
	}

	//Stuff w/ collition detection
	void OnCollisionEnter(Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "shield" && BombAvoider.invincibility == 1) {
			Destroy(this.gameObject);
		}
	}
}
