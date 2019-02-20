using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text timeText;
	public GameObject timeOut;
	public float startTime = 20.0f;

	private bool isGame;
	private int score;
	private float timeLeft;
	private int seconds;


	// Use this for initialization
	void Start () {
		timeOut.SetActive (false);
		score = 0;
		timeLeft = startTime;

		scoreText.text = "Score: " + score;
		timeText.text = "Time: " + seconds;

		isGame = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGame) {
			if (timeLeft > 1) {
				timeLeft -= Time.deltaTime;
				seconds = (int)timeLeft;
				timeText.text = "Time: " + seconds;
			} else {
				isGame = false;
				timeLeft = 0;
				timeOut.SetActive (true);
				Debug.Log ("時間切れ");
			}
		}
	}

	public void AddScore() {
		if (isGame) {
			score++;
			scoreText.text = "Score: " + score;
		}
	}

	public void LoadTitle() {
		SceneManager.LoadScene ("TitleScene");
	}
}
