using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteOfPain : MonoBehaviour
{
    
    public Enemy enemy;

    public GameObject enemySummon;
    public GameObject enemySummoner;

    public float Health;

    void Start(){
        enemy = FindObjectOfType<Enemy>();
        Health = enemy.health;
    }

    void Update(){
        if(Health - enemy.health > 10){
            Health = Health = enemy.health;
            GameObject newEnemySummon = Instantiate(enemySummon, GetRandomNearbyPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomNearbyPosition(){
        float maxDistance = 4f;

        Vector2 randomOffset = Random.insideUnitCircle * maxDistance;

        return enemySummoner.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
    }
}
