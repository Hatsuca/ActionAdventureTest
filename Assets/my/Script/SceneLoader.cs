using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public Text highScoreText;

	// Use this for initialization
	void Start () {
		highScoreText.text = "HighScore: " + GameController.highScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadGameScene() {
		SceneManager.LoadScene ("myScene");
	}
}
