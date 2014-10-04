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
        this.GetComponent<Animator>().SetFloat("velocity", Player.velocity.magnitude);
	}
}
