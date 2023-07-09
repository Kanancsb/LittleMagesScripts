using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaFireballProjectile : MonoBehaviour
{
    // Reference to the BasicSpell script
    public MegaFireball megaFireball;
    
    // Reference to the Rigidbody2D component
    public Rigidbody2D rigidbody;

    public PlayerHealth CurrentHealth;

    public GameObject impacEffect;

    void Start(){
        // Find the BasicSpell component in the scene
        megaFireball = FindObjectOfType<MegaFireball>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();
        
        // Set the velocity of the projectile using the BasicSpell's projectileSpeed value
        rigidbody.velocity = transform.right * megaFireball.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("EnemySpell")){
        Destroy(collision.gameObject);
        return;
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            if (megaFireball.LifeSteal != 0){
                float lifeStealAmount = megaFireball.damage * megaFireball.LifeSteal;
                CurrentHealth.currentHealth += lifeStealAmount;
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
            
                Animator animator = impactInstance.GetComponent<Animator>();
                if (animator != null){
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float animationDuration = stateInfo.length;
                        
                    Destroy(impactInstance, animationDuration);
                }
                else{
                    Destroy(impactInstance);
                }
                enemy.TakeDamage(megaFireball.damage);

            }else{
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
            
                    Animator animator = impactInstance.GetComponent<Animator>();
                    if (animator != null){
                        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                        float animationDuration = stateInfo.length;
                        
                        Destroy(impactInstance, animationDuration);
                    }
                    else{
                        Destroy(impactInstance);
                    }
                enemy.TakeDamage(megaFireball.damage);
            }
        }

        if(!collision.CompareTag("Player")){
            Destroy(gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
