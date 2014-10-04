using UnityEngine;
using System.Collections;

public enum State { Alive = 1, Dead };

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
    public GUIText DeathText;
    [Space(5)]
    [Header("Death texts by cause")]
    public string EndOfTimeString = "You're too slow!!";
    public string WallHitString = "You're retarted!!";
    public string WorkerString = "Are you blind or something?!";
    public string RodFallString = "Noob!\nYou can't even hold rod!";
    public string DefaultDeathString = "You are dead!";
    [Space(5)]
    [Header("")]
    public Explosion ExplosionPlane;

    private State currentState = State.Alive;
    private float timer = 0.0f;

	// Use this for initialization
	void Start () 
    {
        DeathText.enabled = false;
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
                DeathText.enabled = true;
            }
        }
	}

    public void Die(string cause = "Deafult")
    {
        //Some nice explosion particles will be invoked here
        currentState = State.Dead;
        UranusAudio.PlayOneShot(UranusAudio.clip);
        switch(cause)
        {
            case "EndOfTime":
                DeathText.text = EndOfTimeString;
                break;
            case "WallHit":
                DeathText.text = WallHitString;
                break;
            case "Worker":
                DeathText.text = WorkerString;
                break;
            case "RodFall":
                DeathText.text = RodFallString;
                break;
            default:
                DeathText.text = DefaultDeathString;
                break;
        }
    }
}
