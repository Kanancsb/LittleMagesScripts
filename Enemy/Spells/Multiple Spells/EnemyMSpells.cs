using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMSpells : MonoBehaviour
{
    public GameObject impacEffect;

    public bool Burn = false;
    public float BurnDamage;

    public int damage;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start()
    {
        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            impactSound.Play();

            if(Burn){
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                other.gameObject.GetComponent<PlayerHealth>().OverTimeDamage(BurnDamage, 10, true);
            }else{
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
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
