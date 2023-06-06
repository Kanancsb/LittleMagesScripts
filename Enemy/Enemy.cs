using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerKnowledge knowledge;
    public int KnowledgeGain;
    private LivingBomb Livingbomb;
    private WavePBS wavePBS;

    public float health = 100;

    public GameObject LivingBomb;
    bool BombActive;

    public bool SpawnType = true;

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
        wavePBS = FindObjectOfType<WavePBS>();
        Livingbomb = FindObjectOfType<LivingBomb>();
    }

    public void TakeDamage(float damage){
        health -= damage;
        if(Random.Range(0f, 1f) <= Livingbomb.BombChance && Livingbomb.ActiveLB){
            BombActive = true;
            StartCoroutine(LivingBombExplosion());
        }
        if (health <= 0){
            if(Livingbomb.ActiveLB && BombActive){
                StartCoroutine(LivingBombExplosion());
            }else{
                Die();
            }
        }
    }

    void Die(){
        knowledge.Knowledge += KnowledgeGain;
        Destroy(gameObject);
        RemoveFromSpawnedEnemies();
    }

    void RemoveFromSpawnedEnemies(){
        if (wavePBS != null){
            wavePBS.spawnedEnemies.Remove(gameObject);
        }
    }

    IEnumerator LivingBombExplosion(){
        yield return new WaitForSeconds(Livingbomb.Timer);
        BombActive = false;
        LivingBomb.SetActive(true);
    }

    IEnumerator LivingBombDie(){
        LivingBomb.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Die();
    }
}
