using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrb : MonoBehaviour
{
    public PlayerKnowledge Lvls;

    public float Cooldown = 5;
    public float damage = 20f;
    public float LifeSteal = 0;
    public float speed = 2f;
    public float radius = 2f;

    public GameObject Projectile;

    public int maxFireOrbs = 5;
    public int currentFireOrbs = 0;
    private bool canSpawn = true;

    public bool FOChosen = false;

    void Start(){
        speed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        Cooldown *= reductionFactor;
    }

    void Update()
    {
        if (canSpawn && currentFireOrbs < maxFireOrbs){
            StartCoroutine(FireOrbCooldown());
        }
    }

    IEnumerator FireOrbCooldown(){
        canSpawn = false;

        GameObject fireorbProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);

        currentFireOrbs++;

        yield return new WaitForSeconds(Cooldown);

        canSpawn = true;
    }
}
