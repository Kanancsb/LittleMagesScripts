using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGhostProjectile : MonoBehaviour
{
    public FireGhost fireGhost;
    public PlayerKnowledgeController Crit;

    public Rigidbody2D rigidbody;

    public PlayerHealth CurrentHealth;

    public GameObject impactEffect;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){
        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireGhost = FindObjectOfType<FireGhost>();
        CurrentHealth = FindObjectOfType<PlayerHealth>();
        Crit = FindObjectOfType<PlayerKnowledgeController>();
        
        rigidbody.velocity = transform.right * fireGhost.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss")){
            Enemy enemy = collision.GetComponent<Enemy>();
            impactSound.Play();
            if (enemy != null){
                fireGhost.DamageCont += fireGhost.damage;
                if (fireGhost.LifeSteal != 0){
                    float lifeStealAmount = fireGhost.damage * fireGhost.LifeSteal;
                    enemy.TakeDamage(fireGhost.damage, fireGhost.critDamage);
                    CurrentHealth.currentHealth += lifeStealAmount;
                    DestroyAnimation();
                }else{
                    Crit.CritDamage += fireGhost.critDamage;
                    enemy.TakeDamage(fireGhost.damage, fireGhost.critDamage);
                    Crit.CritDamage -= fireGhost.critDamage;
                    DestroyAnimation();
                }
                Destroy(gameObject);
            }
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void DestroyAnimation(){
        GameObject impactInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Animator animator = impactInstance.GetComponent<Animator>();
        if (animator != null){
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float animationDuration = stateInfo.length;

            Destroy(impactInstance, animationDuration);
        }else{
            Destroy(impactInstance);
        }
    }
}
