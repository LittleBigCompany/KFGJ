using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {

    private bool playerDetected;

	// Use this for initialization
	void Start () {
        playerDetected = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerDetected)
        {
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.forward * 10.0f, 0.1f);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") playerDetected = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") Debug.Log("got youre nose!");
    }


}
