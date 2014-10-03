using UnityEngine;
using System.Collections;

public enum State { Alive = 1, Dead };

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
    public string EndOfTimeString = "You're too slow!!";
    public string WallHitString = "You're retarted!!";
    public string DefaultDeathString = "You are dead!";

    private State currentState = State.Alive;
    private float timer = 0.0f;

	// Use this for initialization
	void Start () 
    {
        DeathText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (currentState == State.Dead)
        {
            timer += Time.deltaTime;
            if (!UranusAudio.isPlaying && timer > UranusAudio.clip.length / 2.0f) 
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
            default:
                DeathText.text = DefaultDeathString;
                break;
        }
    }
}
