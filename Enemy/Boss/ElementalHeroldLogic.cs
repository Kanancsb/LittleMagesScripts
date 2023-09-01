using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementalHeroldLogic : MonoBehaviour
{

    // Waves Logic
    public GameObject SecondWave;
    public GameObject ThirdWave;

    // Boss Hud Logic
    public AudioSource BossMusic;
    public GameObject GameOver;
    public GameObject PowerUpHUD;
    
    // Spells Logic
    public List<GameObject> SpellPrefabs = new List<GameObject>();
    public List<Transform> ProjectilePositions = new List<Transform>();
    public float ProjectileCD = 5f;

    // Dialogue Logic
    public List <string> Dialogues = new List<string>();
    public GameObject FloatingTextPrefab;
    public float TextSpeed = 0.1f;
    private Coroutine dialogueCoroutine;
    private bool isDisplayingDialogue = false;

    //HealthBar Logic
    public float Health;
    public HealthBar healthBar;
    public Enemy enemyHealth;

    //
    public TMP_Text WaveHUD;

    void Start(){
        WaveHUD.text = "Elemental Herold!!";
        Health = enemyHealth.health;
        healthBar.SetMaxHealth(Health);

        BossMusic.Play();
        StartCoroutine(ShootSpells());
        StartCoroutine(ShowRandomDialogue());
    }

    // Dialogue System
    IEnumerator DisplayDialogue(string dialogue){
        isDisplayingDialogue = true;
        FloatingTextPrefab.GetComponent<TextMesh>().text = "";

        foreach (char letter in dialogue){
            FloatingTextPrefab.GetComponent<TextMesh>().text += letter;

            yield return new WaitForSeconds(TextSpeed);
        }

        isDisplayingDialogue = false;
    }

    IEnumerator ShowRandomDialogue(){
        yield return new WaitForSeconds(3f);
        if (!isDisplayingDialogue && Dialogues.Count > 0){
            int randomIndex = Random.Range(0, Dialogues.Count);
            string randomDialogue = Dialogues[randomIndex];
            StartCoroutine(DisplayDialogue(randomDialogue));
        }
        StartCoroutine(ShowRandomDialogue());
    }
    // End the Dialogue System

    // Function that randomly triggers the spells
    IEnumerator ShootSpells(){
        yield return new WaitForSeconds(ProjectileCD);

        List<int> randomIndexes = GenerateRandomIndexes(SpellPrefabs.Count);

        foreach (int index in randomIndexes){
            if (index >= 0 && index < SpellPrefabs.Count){
                if (index >= 0 && index < ProjectilePositions.Count){
                    Transform projectilePosition = ProjectilePositions[index];
                    Instantiate(SpellPrefabs[index], projectilePosition.position, projectilePosition.rotation);
                }
            }

            yield return new WaitForSeconds(ProjectileCD);
        }
        StartCoroutine(ShootSpells());
    }

    // Function that shuffles the spells 
    List<int> GenerateRandomIndexes(int count){
        List<int> indexes = new List<int>();
        for (int i = 0; i < count; i++){
            indexes.Add(i);
        }

        for (int i = 0; i < count - 1; i++){
            int randomIndex = Random.Range(i, count);
            int temp = indexes[i];
            indexes[i] = indexes[randomIndex];
            indexes[randomIndex] = temp;
        }

        return indexes;
    }

    void Update(){
        if(GameOver.activeInHierarchy){
            Destroy(BossMusic);
        }
        if(Health > enemyHealth.health){
            Health = enemyHealth.health;
            healthBar.SetHealth(Health);
        }
    }

    void OnDestroy(){
        SecondWave.SetActive(false);
        ThirdWave.SetActive(true);
        PowerUpHUD.SetActive(true);
    }

}
