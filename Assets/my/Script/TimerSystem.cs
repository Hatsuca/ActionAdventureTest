using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

	private Text timerText;
	private bool isGame;
	private float timeLeft;
	int seconds;

	public float maxTime = 10.0f;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();

		timeLeft = maxTime;
		isGame = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGame) {
			if (timeLeft > 1) {
				timeLeft -= Time.deltaTime;
				seconds = (int)timeLeft;
				timerText.text = "Time: " + seconds;
			} else {
				isGame = false;
				timeLeft = 0;
				Debug.Log ("時間切れ");
			}
		}
	}
}
