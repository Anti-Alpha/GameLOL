using UnityEngine;

public class Effect : MonoBehaviour
{
    
    public static Effect Instance;

    public ParticleSystem smokeEffect;

    public ParticleSystem bloodEffect;

    public ParticleSystem hpKolya;
    public ParticleSystem hp;
    public ParticleSystem hpFlexix;

    void Awake()
    {
        Instance = this;
    }

    public void Explosion(Vector3 position)
    {
        instantiate(bloodEffect, position);
    }
    public void Smoke(Vector3 position)
    {
        instantiate(smokeEffect, position);
    }
    public void Hp(Vector3 position)
    {
        instantiate(hp, position);
    }
    public void HpKolyan(Vector3 position)
    {
        instantiate(hpKolya, position);
    }
    public void HpFlex(Vector3 position)
    {
        instantiate(hpFlexix, position);
    }
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}

