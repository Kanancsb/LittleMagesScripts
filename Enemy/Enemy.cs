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

    public float CritChance = 0.1f;
    public float CritDamage = 2;

    void Start(){
        CritChance = 0.1f;
        CritDamage = 2;
        knowledge = FindObjectOfType<PlayerKnowledge>();
        wavePBS = FindObjectOfType<WavePBS>();
        Livingbomb = FindObjectOfType<LivingBomb>();
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(float damage){
        float Critical = Random.Range(0, 1f);
        if(Critical < CritChance){
            damage *= CritDamage;
        }else{
            float damageVariance = damage * Random.Range(-0.15f, 0.05f);
            damage += damageVariance;
        }
        
        health -= damage;

        float bombchanceValue = Random.Range(0f, 1f);
        if (bombchanceValue <= Livingbomb.BombChance && Livingbomb.ActiveLB){
            BombActive = true;
            StartCoroutine(LivingBombExplosion());
        }

        ShowFloatingText(damage);

        if (health <= 0){
            if(Livingbomb.ActiveLB && BombActive){
                StartCoroutine(LivingBombExplosion());
            }else{
                Die();
            }
        }
    }

    // Displays the damage dealt by the character, rounded to an integer
    void ShowFloatingText(float damage){
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        int damageInt = Mathf.RoundToInt(damage);
        go.GetComponent<TextMesh>().text = damageInt.ToString();
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
