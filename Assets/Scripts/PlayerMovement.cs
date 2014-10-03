using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Player/PlayerMovement",0)]

public class PlayerMovement : MonoBehaviour 
{
    [Range(5.0f, 30.0f)]
    public float MovingSpeed;
    [Range(0.0f, 1.0f)]
    public float HandsMovingSpeed;

    public GameObject LeftHand;
    public GameObject RightHand;

    private Quaternion baseRotation;
    private bool rightHandFlag;

	// Use this for initialization
	void Start () 
    {
        baseRotation = LeftHand.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetAxis("Vertical") < -0.3f)
        {
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity,Vector3.forward * MovingSpeed,0.1f);
            if (rightHandFlag)
            {
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingSpeed);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingSpeed);
                if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
            }
            if (!rightHandFlag)
            {
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingSpeed);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingSpeed);
                if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
            }
        }
        else if (Input.GetAxis("Vertical") > 0.3f)
        {
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity,Vector3.forward * -MovingSpeed,0.1f);
            if (rightHandFlag)
            {
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingSpeed);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingSpeed);
                if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
            }
            else if (!rightHandFlag)
            {
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingSpeed);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingSpeed);
                if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
            }
        }
        else
        {   
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity,Vector3.zero,0.1f);
            RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, baseRotation, 0.1f);
            LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, baseRotation, 0.1f);
            if (LeftHand.transform.rotation.x - baseRotation.x > 0.0f) rightHandFlag = true;
            else if (RightHand.transform.rotation.x - baseRotation.x > 0.0f) rightHandFlag = false;
        }
	}
}
