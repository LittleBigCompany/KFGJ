using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Uranus/Uranus")]
public class Uranus : MonoBehaviour {

    public PlayerStateController StateController;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        //this.rigidbody.AddForce(this.transform.right);
	}

    void OnCollisionExit(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Rod")
        {
            StateController.Die("UranusDetonation");
        }
    }
}
