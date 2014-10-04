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

    private Quaternion baseHandsRotation;
    private bool rightHandFlag;
    private bool turnLeftFlag;
    private bool turnRightFlag;
    private int rotationCounter;




	// Use this for initialization
	void Start () 
    {
        if(LeftHand == null || RightHand == null)
        {
            Debug.LogError("no hands");
            Debug.Break();
        }
        baseHandsRotation = LeftHand.transform.rotation;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (StateCont.CurrentState == State.Alive)
        {
            //Moving forward/backward

            if (Input.GetAxis("Vertical") < -0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.forward * MovingVerticalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = false;
                }
                if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            else if (Input.GetAxis("Vertical") > 0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.forward * -MovingVerticalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = false;
                }
                else if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            
            //Moving Left/Right

            if (Input.GetAxis("Horizontal") < -0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.right * -MovingHorizontalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = false;
                }
                if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            else if (Input.GetAxis("Horizontal") > 0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.right * MovingHorizontalSpeed, 0.1f);
                if (rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x + 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x - 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (RightHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = false;
                }
                else if (!rightHandFlag)
                {
                    RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, new Quaternion(RightHand.transform.rotation.x - 0.01f, RightHand.transform.rotation.y, RightHand.transform.rotation.z, RightHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, new Quaternion(LeftHand.transform.rotation.x + 0.01f, LeftHand.transform.rotation.y, LeftHand.transform.rotation.z, LeftHand.transform.rotation.w), HandsMovingVerticalSpeed);
                    if (LeftHand.transform.rotation.x - baseHandsRotation.x > 0.05f) rightHandFlag = true;
                }
            }
            if(rigidbody.velocity == Vector3.zero)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.1f);
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, baseHandsRotation, 0.1f);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, baseHandsRotation, 0.1f);
                if (LeftHand.transform.rotation.x - baseHandsRotation.x > 0.0f) rightHandFlag = true;
                else if (RightHand.transform.rotation.x - baseHandsRotation.x > 0.0f) rightHandFlag = false;
            }
            //Turning Left/Right 90 degres
            if (Input.GetButtonDown("TurnLeft"))
            {
                turnLeftFlag = true;
                rotationCounter = 0;
            }
            if(Input.GetButtonDown("TurnRight"))
            {
                turnRightFlag = true;
                rotationCounter = 0;
            }

            if(turnLeftFlag || turnRightFlag)
            {
                baseHandsRotation.y = RightHand.transform.rotation.y;
                if (turnLeftFlag)
                {
                    transform.Rotate(0.0f, -18.0f, 0.0f);
                    rotationCounter += 1;
                    baseHandsRotation = RightHand.transform.rotation;
                    if (rotationCounter >= 5) turnLeftFlag = false;
                }
                else if(turnRightFlag)
                {
                    transform.Rotate(0.0f, 18.0f, 0.0f);
                    rotationCounter += 1;
                    baseHandsRotation = RightHand.transform.rotation;
                    if (rotationCounter >= 5) turnRightFlag = false;
                }
            }
        }
    }
}
