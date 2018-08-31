using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Use this for initialization
    
    float speed = 0.5f;
    public int damage = 1;
    public bool isEnemyShot = false;
    public GameObject player = null;
    public GameObject bullet;
    float playerX = 0, playerY = 0, bulletX = 0, bulletY = 0, speedX = 0, speedY = 0;
    float maxSpeedX=0,maxSpeedY=0;
	void Start () {
        Destroy(gameObject, 2);
        player = GameObject.FindGameObjectWithTag("Player");

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        bulletX = transform.position.x;
        bulletY = transform.position.y;
        float speed2 = speed / Mathf.Abs(playerX - bulletX) * Mathf.Abs(playerY - bulletY);
        speedX = mMin(Mathf.Abs(playerX - bulletX), speed);
        speedY = mMin(Mathf.Abs(playerY - bulletY), speed2);
        if ((playerX - bulletX) < 0)
            speedX = -speedX;
        if ((playerY - bulletY) < 0)
            speedY = -speedY;

    }
    float mMin(float a, float b)
    {
        if (Mathf.Abs(a) < Mathf.Abs(b))
            return a;
        else
            return b;
    }
	// Update is called once per frame
	void Update () {
        /*print("BulletX " + bulletX);
        print("BulletY " + bulletY);
        print("playerX " + playerX);
        print("playerY " + playerY);*/
        if (isEnemyShot)
        {
            //EffectSoundHelper.Instance.MakekrinjeSound();
            gameObject.transform.position += new Vector3(speedX, speedY, 0);
        }
            else
                gameObject.transform.position += new Vector3(speed, 0, 0);
        
    }
}
