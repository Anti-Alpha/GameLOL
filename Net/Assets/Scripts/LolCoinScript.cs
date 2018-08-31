using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolCoinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    float f = 0;
	void Update () {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, f, 0));
        f += 4;
	}
}
