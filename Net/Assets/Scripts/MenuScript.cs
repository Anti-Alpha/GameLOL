using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        if (GUI.Button (new Rect(500, 70, 300, 100), "PLAY")) Application.LoadLevel ("SampleScene");
        if (GUI.Button (new Rect(500, 180, 140, 75), "Settings")) Application.LoadLevel("SettingsScene");
        if (GUI.Button (new Rect(665, 180, 135, 75), "Shop")) Application.LoadLevel("SampleScene");
        if (GUI.Button (new Rect(500, 270, 300, 90), "Donate")) Application.LoadLevel("SampleScene");
    }
}

