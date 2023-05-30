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

        if (collision.CompareTag("EnemySpell") || collision.CompareTag("Enemy")){
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null){
                if (basicSpell.LifeSteal != 0){
                    float lifeStealAmount = basicSpell.damage * basicSpell.LifeSteal;
                    enemy.TakeDamage(basicSpell.damage);
                    CurrentHealth.currentHealth += lifeStealAmount;
                }else{
                    enemy.TakeDamage(basicSpell.damage);
                }
            }

            Destroy(gameObject);
        }else if(collision.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
