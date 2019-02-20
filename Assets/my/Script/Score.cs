using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text text;
	private int score;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore() {
		score++;
		text.text = "Score: " + score;
	}
}
