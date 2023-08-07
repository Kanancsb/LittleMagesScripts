using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    private PlayerKnowledge knowledge;
    public int KnowledgeGain;
    private LivingBomb Livingbomb;
    private WavePBS wavePBS;

    public bool Boss = false;
    private GameController gameController;

    public float health = 100;

    public GameObject LivingBomb;
    bool BombActive;

    public bool SpawnType = true;

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
        wavePBS = FindObjectOfType<WavePBS>();
        Livingbomb = FindObjectOfType<LivingBomb>();
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(float damage){
        health -= damage;
        if(Random.Range(0f, 1f) <= Livingbomb.BombChance && Livingbomb.ActiveLB){
            BombActive = true;
            StartCoroutine(LivingBombExplosion());
        }

        if(FloatingTextPrefab){
            ShowFloatingText(damage);
        }

        if (health <= 0){
            if(Livingbomb.ActiveLB && BombActive){
                StartCoroutine(LivingBombExplosion());
            }else{
                Die();
            }
        }
    }

    void ShowFloatingText(float damage){
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }

    void Die(){
        if(!Boss){
            knowledge.Knowledge += KnowledgeGain;
            Destroy(gameObject);
            RemoveFromSpawnedEnemies();
        }else if(Boss){
            knowledge.Knowledge += KnowledgeGain;
            knowledge.SavePlayer();
            gameController.cont++;
            Destroy(gameObject);
        }
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
