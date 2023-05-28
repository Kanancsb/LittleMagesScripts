using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerKnowledge knowledge;
    public int KnowledgeGain;

    private WavePBS wavePBS;

    public float health = 100;

    private void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
        wavePBS = FindObjectOfType<WavePBS>();
    }

    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
        knowledge.Knowledge += KnowledgeGain;
        Destroy(gameObject);
        RemoveFromSpawnedEnemies();
    }

    private void RemoveFromSpawnedEnemies(){
        if (wavePBS != null){
            wavePBS.spawnedEnemies.Remove(gameObject);
        }
    }
}
