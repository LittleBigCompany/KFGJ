using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Player/PlayerMovement",0)]

public class PlayerMovement : MonoBehaviour 
{
    [Range(5.0f, 100.0f)]
    public float MovingVerticalSpeed = 10.0f;
    [Range(1.0f, 100.0f)]
    public float MovingHorizontalSpeed = 2.0f;
    [Range(0.0f, 1.0f)]
    public float HandsMovingVerticalSpeed = 0.75f;

    public GameObject LeftHand;
    public GameObject RightHand;

    public PlayerStateController StateCont;

    private Quaternion baseHandslocalRotation;
    private Quaternion rightHandLocalRotBeforeHandsUp;
    private Quaternion leftHandLocalRotBeforeHandsUp;
    private bool rightHandFlag;
    private bool turnLeftFlag;
    private bool turnRightFlag;
    private bool leftHandUp = false;
    private bool rightHandUp = false;
    private bool handsUp = false;
    private bool leftFirst = false;
    private bool rightFirst = false;
    private int localRotationCounter;
    private bool walkForward;

	// Use this for initialization
	void Start () 
    {
        if(LeftHand == null || RightHand == null)
        {
            Debug.LogError("no hands");
            Debug.Break();
        }

        baseHandslocalRotation = LeftHand.transform.localRotation;
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
                walkForward = true;
                if (!leftHandUp && !rightHandUp)
                {
                    if (rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x + 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x - 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = false;
                    }
                    else
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x - 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x + 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = true;
                    }
                }
            }
            else if (Input.GetAxis("Vertical") > 0.3f)
            {
                walkForward = true;
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.forward * -MovingVerticalSpeed, 0.1f);
                if (!leftHandUp && !rightHandUp)
                {
                    if (rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x + 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x - 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = false;
                    }
                    else
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x - 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x + 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = true;
                    }
                }
            }

            if (Input.GetAxis("Vertical") < 0.3f && Input.GetAxis("Vertical") > -0.3f)
            {
                walkForward = false;
            }

            //Moving Left/Right
            if (Input.GetAxis("Horizontal") < -0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.right * MovingHorizontalSpeed, 0.1f);
                if (!leftHandUp && !rightHandUp && !walkForward)
                {
                    if (rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x + 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x - 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = false;
                    }
                    if (!rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x - 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x + 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = true;
                    }
                }
            }
            else if (Input.GetAxis("Horizontal") > 0.3f)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.right * -MovingHorizontalSpeed, 0.1f);
                if (!leftHandUp && !rightHandUp && !walkForward)
                {
                    if (rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x + 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x - 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = false;
                    }
                    if (!rightHandFlag)
                    {
                        RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x - 0.01f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x + 0.01f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed);
                        if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.05f) rightHandFlag = true;
                    }
                }
            }

            //When we stop
            if (rigidbody.velocity == Vector3.zero)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.1f);
                if (!leftHandUp && !rightHandUp)
                {
                    RightHand.transform.localRotation = Quaternion.Slerp(RightHand.transform.localRotation, baseHandslocalRotation, 0.1f);
                    LeftHand.transform.localRotation = Quaternion.Slerp(LeftHand.transform.localRotation, baseHandslocalRotation, 0.1f);
                    if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.0f) rightHandFlag = true;
                    else if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.0f) rightHandFlag = false;
                }
            }

            //Turning Left/Right 90 degrees
            if (Input.GetButtonDown("TurnLeft"))
            {
                turnLeftFlag = true;
                localRotationCounter = 0;
            }
            if (Input.GetButtonDown("TurnRight"))
            {
                turnRightFlag = true;
                localRotationCounter = 0;
            }

            if (turnLeftFlag || turnRightFlag)
            {
                baseHandslocalRotation.y = RightHand.transform.localRotation.y;
                if (turnLeftFlag)
                {
                    transform.Rotate(0.0f, -90.0f, 0.0f);
                    localRotationCounter += 1;
                    baseHandslocalRotation = RightHand.transform.localRotation;
                    turnLeftFlag = false;
        /*            if (localRotationCounter >= 5)
                    {
                        turnLeftFlag = false;
                        //baseHandslocalRotation = new Quaternion(baseHandslocalRotation.x, transform.localRotation.y, baseHandslocalRotation.z, baseHandslocalRotation.w);
                    }*/
                }
                else if (turnRightFlag)
                {
                    transform.Rotate(0.0f, 90.0f, 0.0f);
                    localRotationCounter += 1;
                    baseHandslocalRotation = RightHand.transform.localRotation;
                    turnRightFlag = false;
            /*        if (localRotationCounter >= 5)
                    {
                        turnRightFlag = false;
                       // baseHandslocalRotation = new Quaternion(baseHandslocalRotation.x, RightHand.transform.localRotation.y, baseHandslocalRotation.z, baseHandslocalRotation.w);
                    }*/
                }
            }

            //Stuff with controlling hands
            if ((Input.GetAxis("HandsUp") < -0.0001f || Input.GetMouseButtonDown(1)) && !rightHandUp)
            {
                rightHandUp = true;
                leftHandUp = false;
                handsUp = true;
            }
            else if ((Input.GetAxis("HandsUp") > 0.0001f || Input.GetMouseButtonDown(0)) && !leftHandUp)
            {
                 rightHandUp = false;
                 leftHandUp = true;
                 handsUp = true;
            }

            if(rightHandUp)
            {
                if (handsUp)
                {
                    if (!rightFirst)
                    {
                        rightHandLocalRotBeforeHandsUp = RightHand.transform.localRotation;
                        rightFirst = true;
                    }
                    RightHand.transform.localRotation = Quaternion.Lerp(RightHand.transform.localRotation, new Quaternion(RightHand.transform.localRotation.x + 0.03f, RightHand.transform.localRotation.y, RightHand.transform.localRotation.z, RightHand.transform.localRotation.w), HandsMovingVerticalSpeed * 10.0f);
                    if (RightHand.transform.localRotation.x - baseHandslocalRotation.x > 0.1f)
                    {
                        handsUp = false;
                    }
                }
                else
                {
                    RightHand.transform.localRotation = rightHandLocalRotBeforeHandsUp;
                    rightHandUp = false;
                    rightFirst = false;
                }
            }
            if(leftHandUp)
            {
                if (handsUp)
                {
                    if(!leftFirst)
                    {
                        leftHandLocalRotBeforeHandsUp = LeftHand.transform.localRotation;
                        leftFirst = true;
                    }
                    LeftHand.transform.localRotation = Quaternion.Lerp(LeftHand.transform.localRotation, new Quaternion(LeftHand.transform.localRotation.x + 0.03f, LeftHand.transform.localRotation.y, LeftHand.transform.localRotation.z, LeftHand.transform.localRotation.w), HandsMovingVerticalSpeed * 10.0f);
                    if (LeftHand.transform.localRotation.x - baseHandslocalRotation.x > 0.1f)
                    {
                        handsUp = false;
                    }
                }
                else
                {
                    LeftHand.transform.localRotation = leftHandLocalRotBeforeHandsUp;
                    leftHandUp = false;
                    leftFirst = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, new Quaternion(this.transform.localRotation.x - 0.3f, this.transform.localRotation.y, this.transform.localRotation.z, this.transform.localRotation.w), 0.4f);
            //col.gameObject.collider.enabled = false;           
        }
    }
}
