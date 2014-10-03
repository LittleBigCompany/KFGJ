using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Scripts/GUI/Machine Text", 0)]

public class StartSceneGUIText : MonoBehaviour {

    [Range(0.0001f, 1.0f)]
    public float Rate = 1.0f;
    [Range(0.0f, 1.0f)]
    public float SoundDelay = 150;
    public List<string> TextLines;

    private string text = "";
    private float timer = 0.0f;
    private int i = 0;
    private bool showText = true;

	// Use this for initialization
	void Start () 
    {
        foreach(string txt in TextLines)
        {
            text += txt + "\n";
        }
        text += "\nNacisnij spacje";
        if(this.guiText == null)
        {
            Debug.LogError("ERROR!!! This script should be attached to GUIText!!!");
            Debug.Break();
        }
        else
        {
            this.guiText.text = "";
        }
        timer = Rate + 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (showText)
        {
            if (timer > Rate)
            {
                this.guiText.text += text[i];
                this.GetComponent<AudioSource>().PlayDelayed(SoundDelay);
                i++;
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }

            if (i == text.Length) showText = false;
        }
        else
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
	}
}
