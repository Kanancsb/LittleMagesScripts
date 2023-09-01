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

    private int cont = 0;

    void Start(){

        ImpactSound = GameObject.Find("Hit");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireOrb = FindObjectOfType<FireOrb>();

        CurrentHealth = FindObjectOfType<PlayerHealth>();

        center = GameObject.Find("FireOrbCenter").transform;

        int orbIndex = transform.GetSiblingIndex();
        phaseShift = (float)orbIndex / fireOrb.maxFireOrbs * 2f * Mathf.PI;

        cont = fireOrb.SpellResist;
    }

    void Update(){
        Vector3 offset = new Vector3(Mathf.Sin(Time.time * fireOrb.speed + phaseShift) * fireOrb.radius, Mathf.Cos(Time.time * fireOrb.speed + phaseShift) * fireOrb.radius, 0f);
        transform.position = center.position + offset;
    }

    void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Enemy") || collision.CompareTag("Boss")){
            Enemy enemy = collision.GetComponent<Enemy>();
            impactSound.Play();
            fireOrb.DamageCont += fireOrb.damage;

            if(fireOrb.LifeSteal != 0){
                if(fireOrb.SpellResist >0){
                    float lifeStealAmout = fireOrb.damage * fireOrb.LifeSteal;
                    enemy.TakeDamage(fireOrb.damage);
                    CurrentHealth.currentHealth += lifeStealAmout;
                    fireOrb.SpellResist--;
                    return;
                }else{
                    float lifeStealAmout = fireOrb.damage * fireOrb.LifeSteal;
                    enemy.TakeDamage(fireOrb.damage);
                    CurrentHealth.currentHealth += lifeStealAmout;
                    fireOrb.currentFireOrbs --;
                    Destroy(gameObject);
                }
                
            }else{
                if(fireOrb.SpellResist >0){
                    enemy.TakeDamage(fireOrb.damage);
                    fireOrb.SpellResist--;
                    return;
                }else{
                    enemy.TakeDamage(fireOrb.damage);
                    fireOrb.currentFireOrbs --;
                    Destroy(gameObject);
                }
            }
        }

        if(collision.CompareTag("EnemySpell")){
            impactSound.Play();
            if(fireOrb.SpellResist >0){
                Destroy(collision.gameObject);
                fireOrb.SpellResist--;
                return;
            }else{
                fireOrb.currentFireOrbs --;
                fireOrb.SpellResist = cont;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
