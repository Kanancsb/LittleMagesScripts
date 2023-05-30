using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePBS : MonoBehaviour
{
    public List<EnemyPBS> enemies = new List<EnemyPBS>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    private float waveTimer;
    public float spawnInterval; 
    private float spawnTimer;

    public GameObject UpgradeSkill;
    public GameObject UpgradeWeapon;
    public GameObject Wave01;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        UpgradeSkill.SetActive(false);
        UpgradeWeapon.SetActive(false);
        GenerateWave();
    }

    void FixedUpdate()
    {

        if(UpgradeSkill.activeSelf){
            return;
        }else if(UpgradeWeapon.activeSelf){
            return;
        }
        if (spawnTimer <= 0)
        {
            
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0; 
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {
            if(currWave == 4){
                UpgradeWeapon.SetActive(true);
                currWave++;
                GenerateWave();
            }else if(currWave == 9){
                UpgradeWeapon.SetActive(true);
            }else{
                currWave++;
                GenerateWave();
                UpgradeSkill.SetActive(true);
            }
        }
    }

    public void GenerateWave()
{
    waveValue = currWave * 5;
    GenerateEnemies();

    waveTimer = waveDuration;
    spawnTimer = 0;
}

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class EnemyPBS
{
    public GameObject enemyPrefab;
    public int cost;
}
