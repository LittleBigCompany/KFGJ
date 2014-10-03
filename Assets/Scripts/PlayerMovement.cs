using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Player/PlayerMovement",0)]

public class PlayerMovement : MonoBehaviour 
{
    [Range(5.0f, 30.0f)]
    public float MovingVerticalSpeed = 10.0f;
    [Range(1.0f, 30.0f)]
    public float MovingHorizontalSpeed = 2.0f;
    [Range(0.0f, 1.0f)]
    public float HandsMovingVerticalSpeed = 0.75f;

    public GameObject LeftHand;
    public GameObject RightHand;

    public PlayerStateController StateCont;

    private Quaternion baseRotation;
    private bool rightHandFlag;

	// Use this for initialization
	void Start () 
    {
        if(LeftHand == null || RightHand == null)
        {
            Debug.LogError("no hands");
            Debug.Break();
        }
        baseRotation = LeftHand.transform.rotation;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (StateCont.CurrentState == State.Alive)
        {
            if (Input.GetAxis("Vertical") < -0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.forward * MovingVerticalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
                }
                if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            else if (Input.GetAxis("Vertical") > 0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.forward * -MovingVerticalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
                }
                else if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
                }
             }
            if (Input.GetAxis("Horizontal") < -0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, new Vector3(rigidbody.velocity.x + 1.0f * MovingHorizontalSpeed, rigidbody.velocity.y, rigidbody.velocity.z), 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
                }
                if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            else if (Input.GetAxis("Horizontal") > 0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, new Vector3(rigidbody.velocity.x + 1.0f * -MovingHorizontalSpeed, rigidbody.velocity.y, rigidbody.velocity.z), 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = false;
                }
                else if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            else
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.1f);
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, baseRotation, 0.1f);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, baseRotation, 0.1f);
                if (LeftHand.transform.rotation.x - baseRotation.x > 0.0f) rightHandFlag = true;
                else if (RightHand.transform.rotation.x - baseRotation.x > 0.0f) rightHandFlag = false;
            }    
        }
    }
}
