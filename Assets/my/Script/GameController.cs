using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static int highScore = 0;

	public Text scoreText;
	public Text timeText;
	public GameObject timeOut;
	public GameObject comboBar;
	public GameObject comboScore;
	public float startTime = 20.0f;
	public float comboBaseTime = 5.0f;
	public float comboDecayTime = 0.5f;

	private bool isGame;
	private int score;
	private float timeLeft;
	private int seconds;

	private int combo;
	private float comboTimeLeft;
	private float comboMaxTime;
	private int comboAddScore;
	private Slider comboSlider;
	private Text comboScoreText;

	// Use this for initialization
	void Start () {
		timeOut.SetActive (false);
		comboBar.SetActive (false);
		comboScore.SetActive (false);
		score = 0;
		timeLeft = startTime;
		comboSlider = comboBar.GetComponent<Slider> ();
		comboScoreText = comboScore.GetComponent<Text> ();

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
				EndCombo ();
				isGame = false;
				timeLeft = 0;
				timeOut.SetActive (true);
				Debug.Log ("時間切れ");
			}

			if (combo > 0) {
				comboTimeLeft -= Time.deltaTime;
				comboSlider.value =  comboTimeLeft / comboMaxTime;
				if (comboTimeLeft < 0.1f) EndCombo ();
			}
		}
	}

	public void AddScore() {
		if (isGame) {
			score++;
			scoreText.text = "Score: " + score;
			if (score > highScore) {
				highScore = score;
			}

			combo++;
			comboMaxTime = comboBaseTime - comboDecayTime * combo;
			if (comboMaxTime >= 1.5f) {
				comboTimeLeft = comboMaxTime;
			} else {
				comboTimeLeft = 1.5f;
			}
			comboBar.SetActive (true);
			comboSlider.value = 1.0f;
			comboAddScore = (int)combo / 2;
			if (comboAddScore > 0) {
				comboScore.SetActive (true);
				comboScoreText.text = "+" + comboAddScore;
			}
		}
	}

	private void EndCombo() {
		score += comboAddScore;
		scoreText.text = "Score: " + score;
		if (score > highScore) {
			highScore = score;
		}

		combo = 0;
		comboAddScore = 0;
		comboBar.SetActive (false);
		comboScore.SetActive (false);
	}

	public void LoadTitle() {
		SceneManager.LoadScene ("TitleScene");
	}
}
