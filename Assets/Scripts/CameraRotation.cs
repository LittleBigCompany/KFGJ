using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Camera/Rotation")]

public class CameraRotation : MonoBehaviour {

    public float SensitivyXAxis = 25.0f;
    public float SensitivyYAxis = 45.0f;
    public float MaxLookUpDownAngle = 30.0f;
    public float MaxLookRightLeftAngle = 30.0f;
    public bool InverseXInput = false;
    public bool InverseYInput = false;

    private float rightLeftRotation = 0.0f;
    private float upDownRotation = 0.0f;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 newRotation = new Vector3(0, rightLeftRotation, 0);
        if (InverseXInput)
        {
            rightLeftRotation -= Input.GetAxis("CameraX") * SensitivyXAxis * Time.deltaTime;
        }
        else
        {
            rightLeftRotation += Input.GetAxis("CameraX") * SensitivyXAxis * Time.deltaTime;
        }
        rightLeftRotation = Mathf.Clamp(rightLeftRotation, -MaxLookRightLeftAngle, MaxLookRightLeftAngle);
        newRotation = new Vector3(0, rightLeftRotation, 0);
        this.transform.localRotation = Quaternion.Euler(newRotation);

        if (InverseYInput)
        {
            upDownRotation -= Input.GetAxis("CameraY") * SensitivyYAxis * Time.deltaTime;
        }
        else
        {
            upDownRotation += Input.GetAxis("CameraY") * SensitivyYAxis * Time.deltaTime;
        }
        upDownRotation = Mathf.Clamp(upDownRotation, -MaxLookUpDownAngle, MaxLookUpDownAngle);

        newRotation = new Vector3(upDownRotation, rightLeftRotation, 0);
        this.camera.transform.localRotation = Quaternion.Euler(newRotation);
        this.transform.Rotate(0, 180, 0);
	}
}
