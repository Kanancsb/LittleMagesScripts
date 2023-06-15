using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // Reference to the PowerUpHUD game object
    public GameObject PowerUpHUD;
    public GameObject WeaponPowerUpHUD;

    public GameObject[] WavePBS;
    public GameObject[] Boss;

    public WavePBS Wavepbs01;

    public GameObject[] enemies;

    public int cont = 0;

    // References to the Movement and Spell behaviors
    public Behaviour Movement;
    public Behaviour Spell;

    void FixedUpdate(){

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

            if(Wavepbs01.currWave > 9){
                //SceneManager.LoadScene("MainMenu");
                Boss[0].SetActive(true);
                Wavepbs01.currWave = 1;
                WavePBS[0].SetActive(false);
                Movement.enabled = true;
                Spell.enabled = true;
            }else{
                WavePBS[cont].SetActive(false);
            }

        }else if((!PowerUpHUD.activeInHierarchy || !WeaponPowerUpHUD.activeInHierarchy) && !Boss[cont].activeInHierarchy){
                WavePBS[cont].SetActive(true);
                // Enable the Movement and Spell behaviors
                Movement.enabled = true;
                Spell.enabled = true;
        }
    }
}
