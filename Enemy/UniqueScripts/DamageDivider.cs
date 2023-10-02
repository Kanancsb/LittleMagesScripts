using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDivider : MonoBehaviour
{
    private Enemy enemyHealth;
    float Health;

    public GameObject duplicatePrefab;
    public float spawnDistance = 2f;

    void Start(){
        enemyHealth = FindObjectOfType<Enemy>();
        Health = enemyHealth.health;
    }

    void Update(){
        if(Health - enemyHealth.health > 10 && Health > 100){
            enemyHealth.health /= 2;
            Health = enemyHealth.health;

            float spawnX = Random.Range(0f, 1f) < 0.5f ? transform.position.x - spawnDistance : transform.position.x + spawnDistance;
            Instantiate(duplicatePrefab, new Vector3(spawnX, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
