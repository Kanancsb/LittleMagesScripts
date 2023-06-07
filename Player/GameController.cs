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

    public WavePBS Wavepbs01;

    public GameObject[] enemies;

    int cont = 0;

    // References to the Movement and Spell behaviors
    public Behaviour Movement;
    public Behaviour Spell;

    void FixedUpdate(){

        if(Wavepbs01.currWave > 9){
            SceneManager.LoadScene("MainMenu");
            /*cont++;
            WavePBS[0].SetActive(false);*/
        }

        if(PowerUpHUD.activeInHierarchy || WeaponPowerUpHUD.activeInHierarchy){
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

            WavePBS[cont].SetActive(false);

        }else{
            WavePBS[cont].SetActive(true);
        
            // Enable the Movement and Spell behaviors
            Movement.enabled = true;
            Spell.enabled = true;
        }


    }
}
