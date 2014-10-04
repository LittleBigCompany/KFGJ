using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Uranus/Rod")]
public class Rod : MonoBehaviour {

    public float CentrifugalForce = 10.0f;
    public Transform LeftEnding;
    public Transform RightEnding;
    public PlayerStateController StateController;

    private Vector3 reactorPos = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
	
	}

	// Update is called once per frame
	void Update ()
    {
        if (this.transform.parent != null)
        {
            if (Input.GetButtonDown("TurnLeft"))
            {
                this.rigidbody.AddForceAtPosition(this.transform.parent.parent.right * CentrifugalForce, LeftEnding.position);
            }
            if (Input.GetButtonDown("TurnRight"))
            {
                this.rigidbody.AddForceAtPosition(-this.transform.parent.parent.right * CentrifugalForce, LeftEnding.position);
            }
        }

        if(reactorPos != Vector3.zero)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, reactorPos, 0.5f);
        }
	}

    public void MoveToReactorSlot(Vector3 reactorPosition)
    {
        this.rigidbody.useGravity = false;
        this.transform.parent = null;
        reactorPos = reactorPosition;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Room")
        {
            this.GetComponent<AudioSource>().Play();
            StateController.Die("RodFall");
        }
        else if(col.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            this.transform.parent = col.transform.GetChild(2);
        }
    }
}
