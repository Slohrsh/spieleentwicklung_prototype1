﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void gameWon()
    {
        SceneManager.LoadScene("Win");
    }
}
