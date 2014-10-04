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
        this.guiTexture.color = new Color(this.guiTexture.color.r, this.guiTexture.color.g, this.guiTexture.color.b, this.guiTexture.color.a + 0.01f);
	}
}
