using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public PlayerKnowledge knowledge;

    public int KnowledgeGain;

    public float health = 100;

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
    }

    public void TakeDamage (float damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        knowledge.Knowledge += KnowledgeGain;
        Destroy(gameObject);
    }
}
