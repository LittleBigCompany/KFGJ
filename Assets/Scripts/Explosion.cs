using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Explosion/Explosion Material Fading")]
public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = Camera.main.transform.position + new Vector3(0.0f, 0.0f, -5.0f);

        this.guiTexture.color = new Color(this.guiTexture.color.r, this.guiTexture.color.g, this.guiTexture.color.b, this.guiTexture.color.a + 0.01f);
	}
}
