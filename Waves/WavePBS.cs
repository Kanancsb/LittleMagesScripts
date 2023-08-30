using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePBS : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public List<EnemyPBS> enemies = new List<EnemyPBS>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocationUp;
    public Transform[] spawnLocationDown;
    public int spawnIndexUp;
    public int spawnIndexDown;

    public int waveDuration;
    private float waveTimer;
    public float spawnInterval; 
    private float spawnTimer;
    public int WaveCost;

    public GameObject UpgradeSkill;
    public GameObject UpgradeWeapon;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start(){
        playerHealth = FindObjectOfType<PlayerHealth>();
        UpgradeSkill.SetActive(false);
        UpgradeWeapon.SetActive(false);
        GenerateWave();
    }

    void FixedUpdate(){

        if(UpgradeSkill.activeSelf){
            return;
        }else if(UpgradeWeapon.activeSelf){
            return;
        }

        if (spawnTimer <= 0){
            
            if (enemiesToSpawn.Count > 0){
                GameObject enemy = Instantiate(enemiesToSpawn[0], GetSpawnPosition(), Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;
            }else{
                waveTimer = 0; 
            }
        }else{
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0){
            if(currWave == 4){
                UpgradeWeapon.SetActive(true);
                playerHealth.maxHealth += 5;
                playerHealth.currentHealth += 5;
                currWave++;
                GenerateWave();
            }else{
                currWave++;
                playerHealth.maxHealth += 5;
                playerHealth.currentHealth += 5;
                GenerateWave();
                UpgradeSkill.SetActive(true);
            }
        }
    }

    public void GenerateWave(){
        waveValue = currWave * WaveCost;
        GenerateEnemies();

        waveTimer = waveDuration;
        spawnTimer = 0;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50){
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0){
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0){
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    Vector3 GetSpawnPosition(){
        Vector3 spawnPosition;

        if (enemiesToSpawn[0].GetComponent<Enemy>().SpawnType){
            spawnPosition = spawnLocationUp[spawnIndexUp].position;

            if (spawnIndexUp + 1 <= spawnLocationUp.Length - 1){
                spawnIndexUp++;
            }else{
                spawnIndexUp = 0;
            }
        }else if (enemiesToSpawn[0].GetComponent<Enemy>().SpawnType == false){
            spawnPosition = spawnLocationDown[spawnIndexDown].position;

            if (spawnIndexDown + 1 <= spawnLocationDown.Length - 1){
                spawnIndexDown++;
            }else{
                spawnIndexDown = 0;
            }
        }else{
            spawnPosition = Vector3.zero;
        }

        return spawnPosition;
    }

}

[System.Serializable]
public class EnemyPBS
{
    public GameObject enemyPrefab;
    public int cost;
}
