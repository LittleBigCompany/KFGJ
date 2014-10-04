using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Player/Running controller")]
public class PlayerRunningSoundController : MonoBehaviour {

    public Rigidbody Player;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
        {
            this.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            this.GetComponent<AudioSource>().mute = true;
        }
	}
}
