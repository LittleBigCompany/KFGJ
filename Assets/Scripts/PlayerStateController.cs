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

    public GUIText DeathText;
    public string EndOfTimeString = "You're too slow!!";
    public string WallHitString = "You're retarted!!";
    public string DefaultDeathString = "You are dead!";

    private State currentState = State.Alive;

	// Use this for initialization
	void Start () 
    {
        DeathText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void Die(string cause = "Deafult")
    {
        //Some nice explosion particles will be invoked here
        currentState = State.Dead;
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
        DeathText.enabled = true;
    }
}
