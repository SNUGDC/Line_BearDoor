using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public Text scoreText; 

	// Use this for initialization
	void Start () {
        score = 0;
	}

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }
    void AddScore() {
        score += 1;
        UpdateScore();
    }
}
