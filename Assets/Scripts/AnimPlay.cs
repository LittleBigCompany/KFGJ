using UnityEngine;
using System.Collections;

public class AnimPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Animator>().Play("Run");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
