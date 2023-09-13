using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMissile : MonoBehaviour
{
    public GameObject impacEffect;

    public bool Burn = false;
    public float BurnDamage;

    public int damage;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    public GameObject MissileSpot;

    void Start(){
        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            impactSound.Play();

            if(Burn){
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                other.gameObject.GetComponent<PlayerHealth>().OverTimeDamage(BurnDamage, 10, true);
            }else{
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            AnimationEffect();
            Destroy(MissileSpot);
        }
        if(other.gameObject.CompareTag("Spot")){
            impactSound.Play();
            AnimationEffect();
            Destroy(MissileSpot);
        }
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
