using UnityEngine;
using System.Collections;

public enum State { Alive = 1, Dead, Won };

[AddComponentMenu("Scripts/Player/State Manager")]
public class PlayerStateController : MonoBehaviour {

    public State CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public AudioSource UranusAudio;
    public GUIText DeathGUIText;
    public GUIText WinningGUIText;
    [Space(5)]
    [Header("Death texts by cause")]
    public string EndOfTimeString = "You're too slow!!";
    public string WallHitString = "You're retarted!!";
    public string WorkerString = "Are you blind or something?!";
    public string RodFallString = "Noob!\nYou can't even hold rod!";
    public string UranusDetonationString = "What the fuck was that?!\nRun!!!!";
    public string DefaultDeathString = "You are dead!";
    [Space(5)]
    [Header("Winning string")]
    public string WinningString = "You're lucky man!";
    [Space(5)]
    [Header("")]
    public Explosion ExplosionPlane;

    private State currentState = State.Alive;
    private float timer = 0.0f;

	// Use this for initialization
	void Start () 
    {
        DeathGUIText.enabled = false;
        WinningGUIText.enabled = false;
        ExplosionPlane.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (currentState == State.Dead)
        {
            timer += Time.deltaTime;
            if(timer > UranusAudio.clip.length / 4.0f)
            {
                ExplosionPlane.enabled = true;
            }
            if (timer > UranusAudio.clip.length / 2.0f) 
            {
                DeathGUIText.enabled = true;
            }
        }
	}

    public void Die(string cause = "Deafult")
    {
        //We cannot die twice
        if (currentState == State.Dead) return;

        //We cannot die after we win
        if (currentState == State.Won) return;

        currentState = State.Dead;
        UranusAudio.PlayOneShot(UranusAudio.clip);
        switch(cause)
        {
            case "EndOfTime":
                DeathGUIText.text = EndOfTimeString;
                break;
            case "WallHit":
                DeathGUIText.text = WallHitString;
                break;
            case "Worker":
                DeathGUIText.text = WorkerString;
                break;
            case "RodFall":
                DeathGUIText.text = RodFallString;
                break;
            case "UranusDetonation":
                DeathGUIText.text = UranusDetonationString;
                break;
            default:
                DeathGUIText.text = DefaultDeathString;
                break;
        }
    }

    public void Win()
    {
        if (currentState == State.Alive)
        {
            currentState = State.Won;
            WinningGUIText.text = WinningString;
            WinningGUIText.enabled = true;
        }
    }
}
