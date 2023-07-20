using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrbProjectile : MonoBehaviour
{

    public FireOrb fireOrb;

    public PlayerHealth CurrentHealth;

    public Transform center;

    private float phaseShift;

    void Start(){
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
            fireOrb.currentFireOrbs --;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
