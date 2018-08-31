using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;


    public void Damage(int damageCount)
    {
        hp -= damageCount;
        Effect.Instance.Hp(transform.position);
        if (hp <= 0)
        {
            Application.LoadLevel("Youdied");
            Effect.Instance.Explosion(transform.position);
            Destroy(gameObject);
        }
    }
    private void OnGUI()
    {
        GUIStyle style1 = new GUIStyle();
        style1.fontSize = 40;
        GUI.Label(new Rect(0, 0, 1000, 1000), "Количество жизней:" + hp, style1);
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        BulletScript shot = otherCollider.gameObject.GetComponent<BulletScript>();
        
        if (shot != null)
        {
            print(shot.isEnemyShot.ToString());
            if (!shot.isEnemyShot==isEnemy)
            {
                Damage(shot.damage);

                Destroy(shot.gameObject);
            }
        }
    }
}
