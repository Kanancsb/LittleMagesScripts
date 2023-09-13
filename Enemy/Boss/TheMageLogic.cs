using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheMageLogic : MonoBehaviour
{

    // Boss Hud Logic
    public AudioSource BossMusic;
    public GameObject GameOver;
    //public Animator animation;
    
    // Spells Logic
    public List<GameObject> SpellPrefabs = new List<GameObject>();
    public List<Transform> ProjectilePositions = new List<Transform>();
    public float ProjectileCD = 5f;

    public Animator animator;
    private bool SafeMode = true;

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
        WaveHUD.text = "???????????";
        Health = enemyHealth.health;
        healthBar.SetMaxHealth(Health);

        BossMusic.Play();
        //StartCoroutine(EntranceAnim());
        StartCoroutine(ShowRandomDialogue());
    }

    /*IEnumerator EntranceAnim(){
        AnimationClip currentClip = animation.GetCurrentAnimatorClipInfo(0)[0].clip;
        float animationDuration = currentClip.length;
        yield return new WaitForSeconds(animationDuration);

        Destroy(animation);
    }*/

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
        Debug.Log("ss");
        yield return new WaitForSeconds(ProjectileCD);
        Debug.Log("shoot");

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

    void SpellVolley(){
        EnemyMProjectiles enemyProjectiles = GetComponent<EnemyMProjectiles>();
        if (enemyProjectiles != null){
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpellVolley")){
                enemyProjectiles.enabled = true;
            }else{
                enemyProjectiles.enabled = false;
            }
        }
    }

    void DownVolley(){
        EnemyProjectile enemyProjectile = GetComponent<EnemyProjectile>();
        if (enemyProjectile != null){
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DownVolley")){
                enemyProjectile.enabled = true;
                SafeMode = true;
            }else{
                enemyProjectile.enabled = false;
            }
        }
    }

    void EnemyDance(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyDance") && SafeMode){
            StartCoroutine(ShootSpells());
            SafeMode = false;
        }
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyDance")){
            StopCoroutine(ShootSpells());
        }
    }



    void Update(){
        SpellVolley();
        DownVolley();
        EnemyDance();

        if(Health > enemyHealth.health){
            Health = enemyHealth.health;
            healthBar.SetHealth(Health);
        }

        if(GameOver.activeInHierarchy){
            Destroy(BossMusic);
        }
    }

    void OnDestroy(){
        GameOver.SetActive(true);
    }
}
