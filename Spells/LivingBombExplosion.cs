using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBombExplosion : MonoBehaviour
{

    private LivingBomb bomb;

    private PlayerHealth CurrentHealth;

    void Start(){

        CurrentHealth = FindObjectOfType<PlayerHealth>();

        bomb = FindObjectOfType<LivingBomb>();
    }

    private void OnParticleCollision(GameObject collision){
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            if (bomb.LifeSteal != 0){
                float lifeStealAmount = bomb.damage * bomb.LifeSteal;
                enemy.TakeDamage(bomb.damage);
                CurrentHealth.currentHealth += lifeStealAmount;
            }else{
                enemy.TakeDamage(bomb.damage);
            }
        }
    }
}
