using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameController score { get; set; }
	public GameObject breakSound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "LegCollider") {
			Debug.Log ("hit.");
			if (score != null) {
				score.AddScore ();
			}

			Instantiate (breakSound, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
