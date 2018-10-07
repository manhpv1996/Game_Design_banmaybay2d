﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    Text scoreTextUI;
    int score;
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateTextScoreUI();
        }
    }

    // Use this for initialization
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }
    void UpdateTextScoreUI()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }
    // function to update text score UI 

    // Update is called once per frame
    void Update()
    {

    }
}
