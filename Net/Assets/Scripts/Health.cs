using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;


    public void Damage(int damageCount)
    {
        hp -= damageCount;
        Effect.Instance.Hp(transform.position);
        if (hp <= 0)
        {
            Effect.Instance.Explosion(transform.position);
            Destroy(gameObject);
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
