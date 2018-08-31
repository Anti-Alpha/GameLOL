using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject monster;
    // Use this for initialization
    void Start () {
        Effect.Instance.Smoke(transform.position += new Vector3(0, 0.15f, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Spikes")
        {
            Destroy(gameObject);
            Effect.Instance.Explosion(transform.position);

            Destroy(gameObject);
        }
    }
}
