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

    void Start(){
        // Find the BasicSpell component in the scene
        basicSpell = FindObjectOfType<BasicSpell>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();
        
        // Set the velocity of the projectile using the BasicSpell's projectileSpeed value
        rigidbody.velocity = transform.right * basicSpell.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){
        // Check if the collided object is an Enemy
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null){
            // Apply damage to the enemy using the BasicSpell's damage value
            if(basicSpell.LifeSteal != 0){
                float lifeStealAmout = basicSpell.damage * basicSpell.LifeSteal;
                enemy.TakeDamage(basicSpell.damage);
                CurrentHealth.currentHealth += lifeStealAmout;
            }else{
                enemy.TakeDamage(basicSpell.damage);
            }
        }
        
        // Destroy the projectile object
        Destroy(gameObject);
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
