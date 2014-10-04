using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Uranus/Rod Ending")]
public class RodEnding : MonoBehaviour {

    public PlayerStateController StateController;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Uranus"))
        {
            StateController.Die("UranusDetonation");
        }
    }
}
