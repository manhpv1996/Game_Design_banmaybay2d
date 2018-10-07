using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {
    Text timeUI;
    float startTime;
    float ellapsedTime;
    bool startCounter;//flag to start counter
    int minutes;
    int seconds;
	// Use this for initialization
	void Start () {
        startCounter = false;
        timeUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startCounter)
        {
            // compute ellapse time
            ellapsedTime = Time.time - startTime;
            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;
            timeUI.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        }
	}
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
    }
}
