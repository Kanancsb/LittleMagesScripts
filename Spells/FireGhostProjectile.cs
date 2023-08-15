using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGhostProjectile : MonoBehaviour
{
    public FireGhost fireGhost;

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
        
        rigidbody.velocity = transform.right * fireGhost.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss")){
            Enemy enemy = collision.GetComponent<Enemy>();
            impactSound.Play();
            if (enemy != null){
                if (fireGhost.LifeSteal != 0){
                    float lifeStealAmount = fireGhost.damage * fireGhost.LifeSteal;
                    enemy.TakeDamage(fireGhost.damage);
                    CurrentHealth.currentHealth += lifeStealAmount;
                    GameObject impactInstance = Instantiate(impactEffect, transform.position, transform.rotation);
            
                    Animator animator = impactInstance.GetComponent<Animator>();
                    if (animator != null){
                        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                        float animationDuration = stateInfo.length;
                        
                        Destroy(impactInstance, animationDuration);
                    }else{
                        Destroy(impactInstance);
                    }
                }else{
                    enemy.TakeDamage(fireGhost.damage);
                    GameObject impactInstance = Instantiate(impactEffect, transform.position, transform.rotation);
            
                    Animator animator = impactInstance.GetComponent<Animator>();
                    if (animator != null){
                        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                        float animationDuration = stateInfo.length;
                        
                        Destroy(impactInstance, animationDuration);
                    }
                    else{
                        Destroy(impactInstance);
                    }
                }
            }

            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
