using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrbProjectile : MonoBehaviour
{

    public FireOrb fireOrb;

    public PlayerHealth CurrentHealth;

    public Transform center;

    private float phaseShift;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){

        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireOrb = FindObjectOfType<FireOrb>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();

        center = GameObject.Find("FireOrbCenter").transform;

        int orbIndex = transform.GetSiblingIndex();
        phaseShift = (float)orbIndex / fireOrb.maxFireOrbs * 2f * Mathf.PI;
    }

    void Update(){
        Vector3 offset = new Vector3(Mathf.Sin(Time.time * fireOrb.speed + phaseShift) * fireOrb.radius, Mathf.Cos(Time.time * fireOrb.speed + phaseShift) * fireOrb.radius, 0f);
        transform.position = center.position + offset;
    }

    void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Enemy") || collision.CompareTag("Boss")){

            Enemy enemy = collision.GetComponent<Enemy>();
            impactSound.Play();

            if(fireOrb.LifeSteal != 0){
                float lifeStealAmout = fireOrb.damage * fireOrb.LifeSteal;
                enemy.TakeDamage(fireOrb.damage);
                CurrentHealth.currentHealth += lifeStealAmout;
                fireOrb.currentFireOrbs --;
                Destroy(gameObject);
            }else{
                enemy.TakeDamage(fireOrb.damage);
                fireOrb.currentFireOrbs --;
                Destroy(gameObject);
            }
        }

        if(collision.CompareTag("EnemySpell")){
            impactSound.Play();
            fireOrb.currentFireOrbs --;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
