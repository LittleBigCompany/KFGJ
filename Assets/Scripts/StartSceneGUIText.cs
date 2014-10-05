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
        text += "\nPress space or\n A on XboX360 Controller";
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

            if(Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                this.guiText.text = "";
                foreach(string t in TextLines)
                {
                    this.guiText.text += t + "\n";
                }
                this.guiText.text += "\nPress space or\n A on XboX360 Controller";
                showText = false;
            }
        }
        else
        {
            this.GetComponent<AudioSource>().mute = true;
            if(Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                int level = Random.Range(2, Application.levelCount);
                Debug.Log(level);
                Application.LoadLevel(level);
            }
        }
	}
}
