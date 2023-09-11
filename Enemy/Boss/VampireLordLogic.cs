using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VampireLordLogic : MonoBehaviour
{

    // Begin and End Fight
    public GameObject FirstWave;
    public GameObject SecondWave;
    public GameObject[] Background;

    public GameObject Light;

    public GameObject PowerUpHUD;
    public GameObject GameOver;
    public AudioSource BossMusic;

    // Spell Logic
    int cont = 0;
    bool SpellStop = false;
    public GameObject ProjectilePrefab;
    public Transform ProjectilePosition;
    public float ProjectileCD = 5f;
    public float ActionCD = 5;

    // Health Bar and Teleport Logic
    public HealthBar healthBar;
    private Enemy enemyHealth;
    float Health;
    public float Y = 10f;
    public float X = 10f;

    // Dialogue Logic
    public List<string> Dialogues = new List<string>();
    public GameObject FloatingTextPrefab;
    public float TextSpeed = 0.1f;
    private Coroutine dialogueCoroutine;

    bool FirstSpell = false;

    //
    public TMP_Text WaveHUD;

    void Start(){
        WaveHUD.text = "Vampire Lord!!";
        enemyHealth = FindObjectOfType<Enemy>();
        Health = enemyHealth.health;
        healthBar.SetMaxHealth(Health);
        StartCoroutine(LightAnim());
        BossMusic.Play();
        StartCoroutine(ShootProjectile());
    }

    IEnumerator LightAnim(){
        yield return new WaitForSeconds(4);
        Light.SetActive(false);
    }

// Dialogue Function
    IEnumerator DisplayDialogue(string dialogue){
        FloatingTextPrefab.GetComponent<TextMesh>().text = "";

        // Every TextSpeed seconds, add a character to the dialogue, resets every time is called
        foreach (char letter in dialogue){
            FloatingTextPrefab.GetComponent<TextMesh>().text += letter;

            yield return new WaitForSeconds(TextSpeed);
        }
    }

// Function that triggers spells every ProjectileCD seconds, and the dialogues are displayed on the screen every time the function is called, also shoot the spells
    IEnumerator ShootProjectile(){
        if(!SpellStop){
            yield return new WaitForSeconds(ProjectileCD);
            cont++;

            if (!FirstSpell){
                Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
                FirstSpell = true;
                if (Dialogues.Count > 0){
                    int randomIndex = Random.Range(0, Dialogues.Count);
                    string randomDialogue = Dialogues[randomIndex];
                    dialogueCoroutine = StartCoroutine(DisplayDialogue(randomDialogue));
                }
            }else{
                Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
            }

            if (cont >= 5){
                SpellStop = true;
            }
            StartCoroutine(ShootProjectile());
            
        }else{
            yield return new WaitForSeconds(ActionCD);
            cont = 0;
            SpellStop = false;
            FirstSpell = false;
            StartCoroutine(ShootProjectile());
        }
    }

    void Update(){
        if(Health > enemyHealth.health){
            float teleportX = Random.Range(-X, X);
            float teleportY = Random.Range(1f, Y);
            Vector3 newPosition = new Vector3(teleportX, teleportY, transform.position.z);
            transform.position = newPosition;

            Health = enemyHealth.health;
            healthBar.SetHealth(Health);
        }

        if(GameOver.activeInHierarchy){
            Destroy(BossMusic);
        }
    }

    void OnDestroy(){
        FirstWave.SetActive(false);
        SecondWave.SetActive(true);
        Background[0].SetActive(false);
        Background[1].SetActive(true);
        Light.SetActive(true);
        PowerUpHUD.SetActive(true);
    }

}
