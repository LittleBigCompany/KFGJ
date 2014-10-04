using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<PlayerMovement>().StateCont.Die("WallHit");
            col.rigidbody.AddForceAtPosition(this.transform.position - col.transform.position, col.transform.position + new Vector3(0, 20, 0));
        }
        if(col.gameObject.tag == "Rod")
        {
            col.gameObject.GetComponent<Rod>().StateController.Die("WallHit");
        }
    }
}
