using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoidWatcherLogic : MonoBehaviour
{
    public SteamIntegration integration;
    // Begin and End Fight
    public GameObject FourWave;
    public GameObject FiveWave;
    public GameObject[] Background;

    public GameObject PowerUpHUD;
    public GameObject GameOver;
    public AudioSource BossMusic;
    public Animator animation;

    //HealthBar Logic
    public HealthBar healthBar;
    private Enemy enemyHealth;
    float Health;

    // Dialogue Logic
    public List <string> Dialogues = new List<string>();
    public GameObject FloatingTextPrefab;
    public float TextSpeed = 0.1f;
    private Coroutine dialogueCoroutine;
    private bool isDisplayingDialogue = false;

    //
    public TMP_Text WaveHUD;

    private GameController gameController;

    void Start(){
        integration = FindObjectOfType<SteamIntegration>();
        WaveHUD.text = "Void Watcher!!";
        enemyHealth = FindObjectOfType<Enemy>();
        Health = enemyHealth.health;
        healthBar.SetMaxHealth(Health);
        gameController = FindObjectOfType<GameController>();

        BossMusic.Play();
        StartCoroutine(ShowRandomDialogue());
    }

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

    void Update(){
        if(Health > enemyHealth.health){
            Health = enemyHealth.health;
            healthBar.SetHealth(Health);
        }

        if(GameOver.activeInHierarchy){
            Destroy(BossMusic);
        }
    }

    void OnDestroy(){
        integration.UnlockAchievement("ACH_Boss4");
        FourWave.SetActive(false);
        FiveWave.SetActive(true);
        Background[0].SetActive(false);
        Background[1].SetActive(true);
        PowerUpHUD.SetActive(true);
        gameController.cont++;
    }
}
