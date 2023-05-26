using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave01 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] EnemyPrefab; // Array of enemy prefabs to spawn

    [SerializeField]
    public float EnemyTimer = 3.0f; // Delay between enemy spawns

    public GameObject Wave; // Reference to the wave object

    public GameObject UpgradeSkill; // Reference to the upgrade skill object

    int i = 0; // Index for tracking spawned enemies
    int enemiesRemaining = 0; // Counter for remaining enemies

    void Start(){
        UpgradeSkill.SetActive(false); // Deactivate the upgrade skill object initially
        StartCoroutine(spawnEnemy(EnemyTimer, EnemyPrefab)); // Start spawning enemies
    }

    // Coroutine for spawning enemies with a delay
    private IEnumerator spawnEnemy(float timer, GameObject[] enemies){
        yield return new WaitForSeconds(timer);

        if (i < enemies.Length){
            // Instantiate a new enemy at a random position within specified range
            GameObject newEnemy = Instantiate(enemies[i], new Vector3(Random.Range(-8f, 7.5f), Random.Range(5.5f, 6f), 0), Quaternion.identity);
            i++;
            enemiesRemaining++;
            StartCoroutine(spawnEnemy(EnemyTimer, EnemyPrefab)); // Continue spawning enemies
        }else{
            StartCoroutine(CheckWaveCompletion()); // Start checking wave completion
        }
    }

    // Coroutine for checking wave completion
    private IEnumerator CheckWaveCompletion(){
        while (true){
            yield return null;

            // Find all remaining enemies with the "Enemy" tag
            GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Check if all enemies have been defeated and the total number matches the initial count
            if (remainingEnemies.Length == 0 && enemiesRemaining == EnemyPrefab.Length){
                yield return new WaitForSeconds(1);
                UpgradeSkill.SetActive(true); // Activate the upgrade skill object
                yield break; // Exit the coroutine
            }
        }
    }
}
