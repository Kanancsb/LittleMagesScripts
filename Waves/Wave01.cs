using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave01 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] EnemyPrefab;

    [SerializeField]
    public float EnemyTimer = 3.0f;

    public GameObject Wave;

    int i = 0;

    void Start(){
        StartCoroutine(spawnEnemy(EnemyTimer, EnemyPrefab));
    }

    private IEnumerator spawnEnemy(float timer, GameObject[] enemy){
        yield return new WaitForSeconds(timer);
        if(i < enemy.Length -1){
            GameObject newEnemy = Instantiate(enemy[i], new Vector3(Random.Range(-8f, 7.5f), Random.Range(5.5f, 6f), 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(EnemyTimer, EnemyPrefab));
            i++;
        }else if(i == enemy.Length -1){
            GameObject newEnemy = Instantiate(enemy[i], new Vector3(Random.Range(-8f, 7.5f), Random.Range(5.5f, 6f), 0), Quaternion.identity);
        }
    }
}
