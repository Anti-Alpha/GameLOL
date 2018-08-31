using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    
    // Use this for initialization
    public GameObject platform;
    public GameObject platformWithSpikes;
    public GameObject Enemy;
    public GameObject Batut;
    public GameObject platformBreak;
    public GameObject Stairs;
    public GameObject arzubov;
    public GameObject krinje;
    public GameObject lolCoin;
    public float isSpikeFloat;
    public float isBatutFloat;
    public float isStairFloat;
    public float isBreakFloat;
    private GameObject player;
    float Rast(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        int seed = PlayerPrefs.GetInt("seed", 0);
        PlayerPrefs.SetInt("seed", seed+347);
        float lastX = -24, lastY = 5;
        Boolean lastWasSpike = false;
        for (int i=0; i<100; i++)
        {
            
            Boolean isSpike = false;
            isSpikeFloat = UnityEngine.Random.Range(-50, 50);
            isSpike = (isSpikeFloat >= 0);
            if (isSpike && lastWasSpike)
                isSpike = false;
            Boolean isBatut = false;
            isBatutFloat = UnityEngine.Random.Range(-500, 50);
            isBatut = (isBatutFloat >= 0);
            Boolean isStair = false;
            //isStairFloat = UnityEngine.Random.Range(-100, 50);
            //isStair = (isStairFloat >= 0);
            Boolean isBreak = false;
            isBreakFloat = UnityEngine.Random.Range(-700, 50);
            isBreak = (isBreakFloat >= 0);
            lastWasSpike = isSpike;
            Boolean isCoin = UnityEngine.Random.Range(-150, 50) >= 0;
            Boolean isEnemy = false;
            if (PlayerPrefs.GetString("level") == "hard")
                isEnemy = UnityEngine.Random.Range(-50, 50) >= 0;
            else
                isEnemy = UnityEngine.Random.Range(-150, 50) >= 0;

            if (i == 0)
                Instantiate(platform, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
            else
            {
                if (isSpike)
                    Instantiate(platformWithSpikes, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
                else
                if (isBreak)
                    Instantiate(platformBreak, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
                else
                if (isBatut)
                    Instantiate(Batut, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
                else
                if (isStair)
                    Instantiate(Stairs, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
                else
                {
                    int isType;
                    isType = UnityEngine.Random.Range(0, 2);
                    Instantiate(platform, new Vector2(lastX, lastY), Quaternion.Euler(new Vector3(0, 0, 0)));
                    if (isEnemy && Rast(player.transform.position.x, player.transform.position.y, lastX, lastY) >= 30 && isType == 0)
                    {
                        Instantiate(arzubov, new Vector2(lastX, lastY + 3), Quaternion.Euler(new Vector3(0, 0, 0)));
                    }
                    else if (isEnemy && Rast(player.transform.position.x, player.transform.position.y, lastX, lastY) >= 30 && isType == 1)
                    {
                        Instantiate(krinje, new Vector2(lastX, lastY + 3), Quaternion.Euler(new Vector3(0, 0, 0)));
                    }
                            else if (isCoin)
                                   Instantiate(lolCoin, new Vector2(lastX, lastY + 2.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            }
            float xx = 0, yy = 0;
            do
            {
                xx = UnityEngine.Random.Range(lastX + 5, lastX + 7);
                yy = UnityEngine.Random.Range(lastY - 10, lastY + 7);
            }
            while (yy > 15 || yy < -15);

            lastX = xx;
            lastY = yy;
            
        }
    }

    private float abs(float v)
    {
        if (v > 0)
            return v;
        else
            return -v;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
	}
   
}
