using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class BombAvoider : MonoBehaviour {

	public GameObject playerPrefab;
	public float playerBottomY = -14f;
	
	public GameObject playerLifePrefab;
	public int numLifes = 3;
	public float lifesSpacing = 3f;
	public float playerLifeBottomY = -15f;
	public float playerLifeBottomX = -22.5f;
	public static List<GameObject> lifesList;

	public static int invincibility;

	// Use this for initialization
	void Start () {
		lifesList = new List<GameObject>();
		GameObject tPlayerGO = Instantiate(playerPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.y = playerBottomY;
		tPlayerGO.transform.position = pos;
		invincibility = 0;

		for (int i = 0; i < numLifes; i++) {
			GameObject tPlayerLifeGO = Instantiate(playerLifePrefab) as GameObject;
			Vector3 position = Vector3.zero;
			position.y = playerLifeBottomY+ (lifesSpacing*i);
			position.x = playerLifeBottomX; //+ (lifesSpacing*i);
			tPlayerLifeGO.transform.position = position;
			lifesList.Add(tPlayerLifeGO);
		}
		/*
		GameObject tPlayerLifeGO = Instantiate(playerLifePrefab) as GameObject;
		Vector3 position = Vector3.zero;
		position.y = playerLifeBottomY;
		position.x = -19f;
		tPlayerLifeGO.transform.position = position;
		*/
	}

	public void BombDestroyed() {
		GameObject[]tBombArray = GameObject.FindGameObjectsWithTag("bomb");
		foreach (GameObject tGO in tBombArray)
		{
			Destroy(tGO);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
