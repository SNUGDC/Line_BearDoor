using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour {

    public Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(StartOnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void StartOnClick() {
        SceneManager.LoadScene("testscene");
    }
}
