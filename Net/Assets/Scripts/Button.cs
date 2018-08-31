using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    Collider2D col;
	// Use this for initialization
	void Start () {
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnMouseDown()
    {
        if (col.tag == "Exit") Application.Quit();
        if (col.tag == "Again") Debug.Log("Again");
        if (col.tag == "Information") Application.LoadLevel("INFORMATION Scene");
        if (col.tag == "Volume") Debug.Log("Volume");
        if (col.tag == "Music") Debug.Log("Music");
        if (col.tag == "Vibro Mode") Debug.Log("Vibro Mode");
        if (col.tag == "backToMenu") Application.LoadLevel("Menu");
        if (col.tag == "Settings") Application.LoadLevel("Settings Scene");
        if (col.tag == "Levels") Application.LoadLevel("Slider");
        if (col.tag == "Play") Application.LoadLevel("Game");
        if (col.tag == "Retry") {
            print("loh");
            Application.LoadLevel("Game");
        }
        if (col.tag == "backToMenu") Application.LoadLevel("Menu");
        if (col.tag == "OFF") {
            PlayerPrefs.SetString("level", "easy");
            Application.LoadLevel("Game");
        }
        if (col.tag == "ON")
        {
            PlayerPrefs.SetString("level", "hard");
            Application.LoadLevel("Game");
        }


    }
}
