using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBombExplosion : MonoBehaviour
{

    private LivingBomb bomb;

    private PlayerHealth CurrentHealth;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){

        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();

        bomb = FindObjectOfType<LivingBomb>();
    }

    private void OnParticleCollision(GameObject collision){
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && enemy != gameObject){
            if (bomb.LifeSteal != 0){
                float lifeStealAmount = bomb.damage * bomb.LifeSteal;
                enemy.TakeDamage(bomb.damage, bomb.critDamage);
                CurrentHealth.currentHealth += lifeStealAmount;
            }else{
                enemy.TakeDamage(bomb.damage, bomb.critDamage);
            }
            impactSound.Play();
        }
    }
}
