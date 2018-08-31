using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D rigi;
    public GameObject bullet;
    public GameObject cam;
    public Animator anim;
    float inputX, inputY;
    public float playerPositionX = 0f;
    public float playerPositionY = 0f;
    public int jump = 0;
    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Start () {
        
	}
    private void OnGUI()
    {
        GUIStyle style1 = new GUIStyle();
        style1.fontSize = 40;
        GUI.Label(new Rect(500, 0, 1000, 1000), "Количество ЛОЛ-коинов:"+PlayerPrefs.GetInt("lolCoins"), style1);
    }
    public bool ifLest = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="lolCoin")
        {
            int coins = PlayerPrefs.GetInt("lolCoins");
            PlayerPrefs.SetInt("lolCoins", coins + 1);
            Destroy(collider.gameObject);
        }
        if (collider.tag=="Break")
        {
            Destroy(collider.gameObject, 1);
        }
        if (collider.tag == "ground" || collider.tag=="Break")
        {
            jump = 0;
        }
        if (collider.tag == "Spikes")
        {
            //anim.Play("Exp");
            Application.LoadLevel("Youdied");
            Destroy(gameObject);
            int coins = PlayerPrefs.GetInt("lolCoins");
            PlayerPrefs.SetInt("lolCoins", coins - 4);
            //Instantiate(monster, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
            Effect.Instance.Explosion(transform.position);

        }
        if (collider.tag == "batut")
        {
            rigi.AddForce(new Vector2(0, 2000));
            jump = 1;

        }
        if (collider.tag == "Lestnica")
        {
            rigi.gravityScale = -1;
            jump = 0;
        }
    }
    public string s = "left";
    void Update()
    {
        playerPositionY = gameObject.transform.position.y;
        if (playerPositionY<-15)
        {
            Application.LoadLevel("Youdied");
            Destroy(gameObject);
        }
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        rigi.gravityScale = 5;
        if (moveHor > 0)
        {
            anim.Play("Run");

            s = "right";
        }
        else if (moveHor == 0 && s == "right")
            anim.Play("idle");
        else if (moveHor < 0)
        {
            anim.Play("fliprun");
            s = "left";
        }
        else if (moveHor == 0 && s == "left")  {
            anim.Play("idleflip");
        }
        else if (moveVer > 0 && moveHor > 0)    {
            anim.Play("jump");
        } else if (Input.GetKeyDown(KeyCode.LeftControl))   {
            anim.Play("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("PauseScene");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.Play("Attack");
            Instantiate(bullet, gameObject.transform.position + new Vector3(2, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && jump < 2 )
        {
            if (jump == 0)
                rigi.AddForce(new Vector2(0, 1200));
            else
                rigi.AddForce(new Vector2(0, 800));
            jump++;
        }
       
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigi.transform.position += new Vector3(0.15f, 0, 0); 
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigi.transform.position += new Vector3(-0.15f, 0, 0);
        }
        cam.transform.position = new Vector3(rigi.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }


}

