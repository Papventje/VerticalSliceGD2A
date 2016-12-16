using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
	
	public Text hiScoreText;
	public static float hiScore;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) 
		{
			hiScore = PlayerPrefs.GetFloat("HighScore");
		}
	}

	// Update is called once per frame
	void Update () {
		hiScoreText.text = "Highscore: " + hiScore;

		if (Score.score > hiScore) 
		{
			hiScore = Score.score;
			PlayerPrefs.SetFloat ("HighScore", hiScore);
		}
	}
}
