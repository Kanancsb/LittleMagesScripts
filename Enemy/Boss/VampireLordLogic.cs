using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VampireLordLogic : MonoBehaviour
{

    public GameObject Light;

    public GameObject PowerUpHUD;
    public GameObject GameOver;
    public AudioSource BossMusic;

    int cont = 0;
    bool SpellStop = false;

    public GameObject ProjectilePrefab;
    public Transform ProjectilePosition;
    
    public float ProjectileCD = 5f;
    public float ActionCD = 5;

    private Enemy enemyHealth;
    float Health;
    public float Y = 10f;
    public float X = 10f;

    public List<string> Dialogues = new List<string>();
    public TextMeshProUGUI BossDialogue;
    bool FirstSpell = false;
    public float TextSpeed = 0.1f;
    private Coroutine dialogueCoroutine;

    public GameObject TY;

    void Start(){
        enemyHealth = FindObjectOfType<Enemy>();
        Health = enemyHealth.health;
        Light.SetActive(false);
        BossMusic.Play();
        StartCoroutine(ShootProjectile());
    }

    IEnumerator DisplayDialogue(string dialogue)
    {
        BossDialogue.text = "";

        foreach (char letter in dialogue)
        {
            BossDialogue.text += letter;

            yield return new WaitForSeconds(TextSpeed);
        }
    }

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
        }

        if(GameOver.activeInHierarchy){
            Destroy(BossMusic);
        }
    }

    void OnDestroy(){
        TY.SetActive(true);
        Time.timeScale = 0;
        /*Light.SetActive(true);
        PowerUpHUD.SetActive(true);*/
    }

}
