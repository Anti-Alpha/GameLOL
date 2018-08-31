using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrinjeEnemy : MonoBehaviour
{
    public GameObject krinje;
    public GameObject bullet;
    private GameObject player;
    float timer = 0f, coolDown = 5f;
    public float playerPositionX = 0f;
    public float playerPositionY = 0f;
    float Rast(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
    void Start()
    {
        Effect.Instance.Smoke(transform.position += new Vector3(0, 5, 0));
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

        timer += UnityEngine.Time.deltaTime;
        if (timer>=coolDown && player!=null && Rast(krinje.transform.position.x, krinje.transform.position.y, player.transform.position.x, player.transform.position.y) <= 30f)
        { 
            Instantiate(bullet, krinje.transform.position, Quaternion.Euler(0, 0, 0));
            timer = 0;
        }
        playerPositionY = gameObject.transform.position.y;
        if (playerPositionY < -15)
        {
            Destroy(gameObject);
            int coins = PlayerPrefs.GetInt("lolCoins");
            PlayerPrefs.SetInt("lolCoins", coins + 1);
        }      
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Spikes")
        {
            Destroy(gameObject);
            Effect.Instance.Explosion(transform.position);
            int coins = PlayerPrefs.GetInt("lolCoins");
            PlayerPrefs.SetInt("lolCoins", coins + 1);
            Destroy(gameObject);
        }

    }
}
