using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissileProjectile : MonoBehaviour
{
    // Reference to the BasicSpell script
    public FireMissile fireMissile;
    
    // Reference to the Rigidbody2D component
    public Rigidbody2D rigidbody;

    public PlayerHealth CurrentHealth;

    int hitCont = 0;

    void Start(){
        // Find the BasicSpell component in the scene
        fireMissile = FindObjectOfType<FireMissile>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();
        
        // Set the velocity of the projectile using the BasicSpell's projectileSpeed value
        rigidbody.velocity = transform.right * fireMissile.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D collision){

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && hitCont == 0){
            if (fireMissile.LifeSteal != 0){
                float lifeStealAmount = fireMissile.damage * fireMissile.LifeSteal;
                enemy.TakeDamage(fireMissile.damage);
                CurrentHealth.currentHealth += lifeStealAmount;
                hitCont++;
            }else{
                enemy.TakeDamage(fireMissile.damage);
                hitCont++;
            }
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
