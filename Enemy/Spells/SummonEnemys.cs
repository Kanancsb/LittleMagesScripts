using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemys : MonoBehaviour
{
    
    [SerializeField]
    public GameObject[] enemySummon;

    [SerializeField]
    public GameObject enemySummoner;

    [SerializeField]
    public float EnemyTimer = 3.0f;

    public List<GameObject> summonedEnemies = new List<GameObject>();

    int i = 0;

    void Start(){
        if(enemySummoner.activeInHierarchy){
            StartCoroutine(spawnEnemy(EnemyTimer, enemySummon, enemySummoner.transform.position));
        }
    }

    private IEnumerator spawnEnemy(float timer, GameObject[] enemy, Vector3 summonerPosition){
        yield return new WaitForSeconds(timer);
        i = Random.Range(0, enemy.Length);
        GameObject newEnemy = Instantiate(enemy[i], GetRandomPositionNearSummoner(summonerPosition), Quaternion.identity);
        StartCoroutine(spawnEnemy(EnemyTimer, enemySummon, summonerPosition));
        summonedEnemies.Add(newEnemy);
    }

    private Vector3 GetRandomPositionNearSummoner(Vector3 summonerPosition){
        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        return summonerPosition + randomOffset;
    }
}
