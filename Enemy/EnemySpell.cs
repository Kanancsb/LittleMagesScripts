using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rigidbody;

    public GameObject impacEffect;

    public bool Burn = false;
    public float BurnDamage;

    public int damage;

    public float Speed;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){

        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        // Get the Rigidbody2D component attached to the enemy spell
        rigidbody = GetComponent<Rigidbody2D>();

        // Find the player object using the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Calculate the direction from the enemy spell to the player
        Vector3 direction = player.transform.position - transform.position;

        // Set the velocity of the enemy spell to move towards the player
        rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * Speed;

        // Calculate the rotation angle to face the player
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the enemy spell
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D other){
        // Check if the enemy spell collides with the player
        if (other.gameObject.CompareTag("Player")){
            impactSound.Play();

            // Deal damage to the player
            if(Burn){
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                other.gameObject.GetComponent<PlayerHealth>().OverTimeDamage(BurnDamage, 10, true);
            }else{
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }

            if(impacEffect != null){
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
                Animator animator = impactInstance.GetComponent<Animator>();

                if (animator != null){
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float animationDuration = stateInfo.length;
                    
                    Destroy(impactInstance, animationDuration);
                }
            }
            
            Destroy(gameObject);
        }else if(other.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            impactSound.Play();
            if(impacEffect != null){
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
                Animator animator = impactInstance.GetComponent<Animator>();

                if (animator != null){
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float animationDuration = stateInfo.length;
                    
                    Destroy(impactInstance, animationDuration);
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
