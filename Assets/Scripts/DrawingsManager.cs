using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Drawings/DrawingsManager",0)]

public class DrawingsManager : MonoBehaviour {

    public Texture[] Textures = new Texture[12];

    private int chose;

	// Use this for initialization
	void Start () {
        chose = Random.Range(0,Textures.Length);
        this.renderer.material.mainTexture = Textures[chose];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
