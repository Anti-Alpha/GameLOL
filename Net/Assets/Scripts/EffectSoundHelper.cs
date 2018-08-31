using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundHelper : MonoBehaviour {

    // Use this for initialization
    public static EffectSoundHelper Instance;
    public AudioClip kolyanShot;
    public AudioClip krinjeShot;
    //public AudioClip Explosion;

    private void Awake()
    {
        Instance = this;
    }
    //public void MakeExplosionSound(){
    //    MakeSound(Explosion);
    //}
    public void MakekolyanSound()
    {
        MakeSound(kolyanShot);
    }
    public void MakekrinjeSound()
    {
        MakeSound(krinjeShot);
    }
    void Start () {
		
	}
    private void MakeSound(AudioClip sound) {
    AudioSource.PlayClipAtPoint(sound, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
