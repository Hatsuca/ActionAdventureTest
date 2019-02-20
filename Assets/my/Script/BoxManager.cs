using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

	private float spawnTime;
	private Vector2 randomPos;
	private Vector3 spawnPos;
	Quaternion spawnRot;

	public GameObject boxPrefab;
	public Score scoreObject;
	public float spawnWait = 5.0f;
	public float spawnAreaRadius = 10.0f;

	// Use this for initialization
	void Start () {
		spawnTime = 0;

		for (int i = 0; i < 5; i++) {
			SpawnBox ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		spawnTime += Time.deltaTime;
		if (spawnTime > spawnWait) {
			spawnTime = 0;
			SpawnBox ();
		}
	}

	void SpawnBox () {
		randomPos = Random.insideUnitCircle * spawnAreaRadius;
		spawnPos = new Vector3 (randomPos.x, 1.0f, randomPos.y);
		spawnRot = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.up);
		GameObject box = Instantiate (boxPrefab, spawnPos, spawnRot, this.transform);
		box.GetComponent<Box> ().score = scoreObject;
	}
}
