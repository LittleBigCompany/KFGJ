using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Reactor/Reactor")]
public class Reactor : MonoBehaviour {

    public PlayerStateController StateController;
    public Vector3 RodOffsetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Rod")
        {
            StateController.Win();
            this.collider.enabled = false;
            col.gameObject.GetComponent<Rod>().MoveToReactorSlot(this.transform.position + RodOffsetPosition);
        }
        else if(col.gameObject.tag == "Player")
        {
            StateController.Win();
        }
    }
}
