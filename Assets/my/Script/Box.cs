using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public Score score { get; set; }

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

			Destroy(gameObject);
		}
	}
}
