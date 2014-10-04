using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Uranus/Rod")]
public class Rod : MonoBehaviour {

    public float CentrifugalForce = 10.0f;
    public Transform LeftEnding;
    public Transform RightEnding;
    public PlayerStateController StateController;

    private bool isLeftHandHoldingMe = true;
    private bool isRightHandHoldingMe = true;

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
	}

    void LateUpdate()
    {
        if (!isLeftHandHoldingMe && !isRightHandHoldingMe)
        {
            this.transform.parent = null;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "LeftHand")
        {
            isLeftHandHoldingMe = true;
        }
        else if (col.gameObject.tag == "RightHand")
        {
            isRightHandHoldingMe = true;
        }
        else if(col.gameObject.tag == "Room")
        {
            StateController.Die("RodFall");
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "LeftHand")
        {
            isLeftHandHoldingMe = false;
        }
        else if (col.gameObject.tag == "RightHand")
        {
            isRightHandHoldingMe = false;
        }
    }
}
