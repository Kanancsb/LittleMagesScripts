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

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){
        ImpactSound = GameObject.Find("Hit1");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireMissile = FindObjectOfType<FireMissile>();
        CurrentHealth = FindObjectOfType<PlayerHealth>();
        
        rigidbody.velocity = transform.right * fireMissile.projectileSpeed;

        StartCoroutine(ProjectileFade());
    }

    void Update(){
        if(fireMissile.Imbuement){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rigidbody.velocity.normalized, 0.1f);
            if (hit.collider != null){
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Bricks")){
                        Vector2 reflectDirection = Vector2.Reflect(rigidbody.velocity.normalized, hit.normal);
                        rigidbody.velocity = reflectDirection * fireMissile.projectileSpeed;
                        Flip();
                        impactSound.Play();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            fireMissile.DamageCont += fireMissile.damage;
            if (fireMissile.LifeSteal != 0){
                float lifeStealAmount = fireMissile.damage * fireMissile.LifeSteal;
                enemy.TakeDamage(fireMissile.damage, fireMissile.critDamage);
                CurrentHealth.currentHealth += lifeStealAmount;
            }else{
                enemy.TakeDamage(fireMissile.damage, fireMissile.critDamage);
            }
            impactSound.Play();
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void Flip(){
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

}
