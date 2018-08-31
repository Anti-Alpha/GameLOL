using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {

        if (GUI.Button(new Rect(475, 180, 150, 80), "ON")) { }
        if (GUI.Button(new Rect(650, 180, 150, 80), "OFF")) { }
        if (GUI.Button(new Rect(475, 275, 325, 75), "Back")) Application.LoadLevel("SceneMenu");
    }
}
