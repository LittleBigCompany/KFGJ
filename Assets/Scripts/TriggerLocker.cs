using UnityEngine;
using System.Collections;


[AddComponentMenu("Scripts/Worker/TriggerLocker",0)]
public class TriggerLocker : MonoBehaviour {

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPosition;
	}
}
