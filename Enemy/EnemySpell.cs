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

    public FireArmor fireArmor;

    void Start(){

        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        fireArmor = FindObjectOfType<FireArmor>();

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
        if (other.gameObject.CompareTag("Player")){
            impactSound.Play();

            if(Burn){
                if(fireArmor.FireArmorSpell){
                    fireArmor.Backslash(damage, GetComponent<Enemy>(), impactSound);
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                }else{
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
                other.gameObject.GetComponent<PlayerHealth>().OverTimeDamage(BurnDamage, 10, true);
            }else{
                if(fireArmor.FireArmorSpell){
                    fireArmor.Backslash(damage, GetComponent<Enemy>(), impactSound);
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                }else{
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }

            AnimationEffect();
            Destroy(gameObject);
        }else if(other.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            impactSound.Play();
            AnimationEffect();
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void AnimationEffect(){
        if(impacEffect != null){
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
                Animator animator = impactInstance.GetComponent<Animator>();

                if (animator != null){
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float animationDuration = stateInfo.length;
                    
                    Destroy(impactInstance, animationDuration);
                }
            }
    }

}
