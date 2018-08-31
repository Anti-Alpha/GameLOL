using UnityEngine;

public class HealthKolya : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;


    public void Damage(int damageCount)
    {
        hp -= damageCount;
        Effect.Instance.HpKolyan(transform.position);
        if (hp <= 0)
        {
            //Effect.Instance.Explosion(transform.position);
            Destroy(gameObject);
            int coins = PlayerPrefs.GetInt("lolCoins");
            PlayerPrefs.SetInt("lolCoins", coins + 1);
        }
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
