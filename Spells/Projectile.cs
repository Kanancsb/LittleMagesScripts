using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Reference to the BasicSpell script
    public BasicSpell basicSpell;
    
    // Reference to the Rigidbody2D component
    public Rigidbody2D rigidbody;

    public PlayerHealth CurrentHealth;

    public GameObject impactEffect;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){
        
        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        basicSpell = FindObjectOfType<BasicSpell>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();
        
        // Set the velocity of the projectile using the BasicSpell's projectileSpeed value
        rigidbody.velocity = transform.right * basicSpell.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("EnemySpell") || collision.CompareTag("Enemy") || collision.CompareTag("Boss")){
            Enemy enemy = collision.GetComponent<Enemy>();
            impactSound.Play();
            if (enemy != null){
                if (basicSpell.LifeSteal != 0){
                    float lifeStealAmount = basicSpell.damage * basicSpell.LifeSteal;
                    enemy.TakeDamage(basicSpell.damage);
                    CurrentHealth.currentHealth += lifeStealAmount;
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
                }else{
                    enemy.TakeDamage(basicSpell.damage);
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
        }else if(collision.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            impactSound.Play();
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
