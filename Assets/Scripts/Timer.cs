﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/GUI/Timer")]

public class Timer : MonoBehaviour {

    [Tooltip("This is time in minutes")]
    public float TimeLeft = 10.0f;
    public PlayerStateController StateController;
    public GUIText GUITimer;
    public bool ShowTimer = true;
    public AudioSource PlayerAudio;

    private float timer = 0.0f;
    private bool isGeigerPlaying = false;
    private float soundTimer = 0.0f;
    private float soundDuration = 0.0f;

	// Use this for initialization
	void Start () 
    {
        GUITimer.enabled = ShowTimer;
        soundDuration = PlayerAudio.clip.length;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (StateController.CurrentState == State.Alive)
        {
            timer += Time.deltaTime;
            float timeLeft = (60 * TimeLeft - timer) / 60.0f;
            if(timeLeft < 1.0f)
            {
                if(!isGeigerPlaying)
                {
                    PlayerAudio.PlayOneShot(PlayerAudio.clip);
                    isGeigerPlaying = true;
                }
                else
                {
                    soundTimer += Time.deltaTime;
                    if(soundTimer > soundDuration + timeLeft)
                    {
                        soundTimer = 0.0f;
                        isGeigerPlaying = false;
                    }
                }

            }
            if (timer / 60.0f > TimeLeft)
            {
                StateController.Die("EndOfTime");
            }
            if (ShowTimer)
            {
                GUITimer.text = ConvertSecondsToMinutes(60 * TimeLeft - timer);
            }
        }
	}

    public static string ConvertSecondsToMinutes(float sec)
    {
        int seconds = (int)sec;
        int minutes = (int)seconds / 60;
        seconds = seconds - minutes * 60;
        string time = "";
        if (minutes < 10)
        {
            time += "0";
            time += minutes.ToString();
        }
        else
        {
            time += minutes.ToString();
        }

        time += ":";

        if (seconds < 10)
        {
            time += "0";
            time += seconds.ToString();
        }
        else
        {
            time += seconds.ToString();
        }
        return time;
    }
}
