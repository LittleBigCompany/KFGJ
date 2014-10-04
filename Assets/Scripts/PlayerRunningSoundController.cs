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
        if (Input.GetAxis("Vertical") != 0.0f)
        {
            this.GetComponent<Animator>().SetFloat("velocity", Player.velocity.magnitude);
        }
        else
        {
            this.GetComponent<Animator>().SetFloat("velocity", 0.0f);
        }
	}
}
