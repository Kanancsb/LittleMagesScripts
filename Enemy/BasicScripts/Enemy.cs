using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerKnowledgeController Lvls;

    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefabCrit;

    private PlayerKnowledge knowledge;
    public int KnowledgeGain;

    private LivingBomb Livingbomb;
    private WavePBS wavePBS;

    public bool Boss = false;

    public float health = 100;

    public GameObject LivingBomb;
    bool BombActive;

    public bool SpawnType = true;

    void Start(){
        Lvls = FindObjectOfType<PlayerKnowledgeController>();
        knowledge = FindObjectOfType<PlayerKnowledge>();
        wavePBS = FindObjectOfType<WavePBS>();
        Livingbomb = FindObjectOfType<LivingBomb>();
    }

    public void TakeDamage(float damage, float critdamage){
        damage *= ((knowledge.DamageLevel - 1) * 0.05f) + 1f;
        float Critical = Random.Range(0, 1f);
        if(Critical < Lvls.CritChance){
            damage *= critdamage;
            ShowFloatingTextCrit(damage);
        }else{
            float damageVariance = damage * Random.Range(-0.15f, 0.05f);
            damage += damageVariance;
            ShowFloatingText(damage);
        }
        
        if(damage < 1){
            damage = 1;
        }
        health -= damage;

        float bombchanceValue = Random.Range(0f, 1f);
        if (bombchanceValue <= Livingbomb.BombChance && Livingbomb.ActiveLB){
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

    // Displays the damage dealt by the character, rounded to an integer
    void ShowFloatingText(float damage){
        Vector3 spawnPosition = transform.position + new Vector3(0, 0.5f, 0);
        var go = Instantiate(FloatingTextPrefab, spawnPosition, Quaternion.identity);
        int damageInt = Mathf.RoundToInt(damage);
        go.GetComponent<TextMesh>().text = damageInt.ToString();
    }

    void ShowFloatingTextCrit(float damage){
        Vector3 spawnPosition = transform.position + new Vector3(0, 0.5f, 0);
        var go = Instantiate(FloatingTextPrefabCrit, spawnPosition, Quaternion.identity);
        int damageInt = Mathf.RoundToInt(damage);
        go.GetComponent<TextMesh>().text = damageInt.ToString() + "!!";
    }

    void Die(){
        if(!Boss){
            knowledge.Knowledge += KnowledgeGain;
            Destroy(gameObject);
            RemoveFromSpawnedEnemies();
        }else if(Boss){
            knowledge.Knowledge += KnowledgeGain;
            knowledge.SavePlayer();
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
