using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerKnowledge Lvls;

    // Reference to the PowerUpHUD game object
    public GameObject PowerUpHUD;
    public GameObject WeaponPowerUpHUD;

    public GameObject[] WavePBS;
    public GameObject[] Boss;

    public WavePBS Wavepbs01;
    public WavePBS Wavepbs02;
    public WavePBS Wavepbs03;

    public GameObject[] enemies;
    public GameObject[] enemySpells;

    public int cont = 0;

    // References to the Movement and Spell behaviors
    public Behaviour Movement;
    public Behaviour Spell;

    public int Reroll;

    void Start(){
        Reroll = Lvls.RerollLevel - 1;
    }

    void Update(){

        if((PowerUpHUD.activeInHierarchy || WeaponPowerUpHUD.activeInHierarchy) && !Boss[cont].activeInHierarchy){
            // Set the cursor visibility and lock state
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            // Disable the Movement and Spell behaviors
            Movement.enabled = false;
            Spell.enabled = false;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies){
                Destroy(enemy);
            }

            GameObject[] enemySpells = GameObject.FindGameObjectsWithTag("EnemySpell");
            foreach (GameObject enemySpell in enemySpells)
            {
                Destroy(enemySpell);
            }

        }else if((!PowerUpHUD.activeInHierarchy || !WeaponPowerUpHUD.activeInHierarchy) && !Boss[cont].activeInHierarchy){
            if(Wavepbs01.currWave > 9){
                Wavepbs01.currWave = 1;
                WavePBS[0].SetActive(false);
                Boss[0].SetActive(true);
                Movement.enabled = true;
                Spell.enabled = true;
            }else if(Wavepbs02.currWave > 9){
                Wavepbs02.currWave = 1;
                WavePBS[1].SetActive(false);
                Boss[1].SetActive(true);
                Movement.enabled = true;
                Spell.enabled = true;
            }else if(Wavepbs03.currWave > 9){
                Wavepbs02.currWave = 1;
                WavePBS[2].SetActive(false);
                Boss[2].SetActive(true);
                Movement.enabled = true;
                Spell.enabled = true;
            }else{
                WavePBS[cont].SetActive(true);
                Movement.enabled = true;
                Spell.enabled = true;
            }
        }
    }
}
