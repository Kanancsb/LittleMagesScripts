using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPowerUp : MonoBehaviour
{
    // Reference to the BasicSpell script
    public BasicSpell basicSpell;
    
    // Reference to the PlayerMovement script
    public PlayerMovement playerMovement;

    // Reference to the PowerUpHUD game object
    public GameObject PowerUpHUD;

    public GameObject WavePBS;

    public GameObject[] enemies;

    // References to the Movement and Spell behaviors
    public Behaviour Movement;
    public Behaviour Spell;


    void FixedUpdate(){
        if(PowerUpHUD.activeInHierarchy){
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

            WavePBS.SetActive(false);

        }
    }

    public void FireballPowerUpDamage01(){
        // Increase the damage of the basic spell by 5
        basicSpell.damage = basicSpell.damage + 5;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
        WavePBS.SetActive(true);
        
        // Enable the Movement and Spell behaviors
        Movement.enabled = true;
        Spell.enabled = true;
    }

    public void FireballPowerUpCD01(){
        // Decrease the cast cooldown of the basic spell by 10%
        basicSpell.CastCD = basicSpell.CastCD * 0.9f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
        WavePBS.SetActive(true);
        
        // Enable the Movement and Spell behaviors
        Movement.enabled = true;
        Spell.enabled = true;
    }

    public void FireballPowerUpSpeed01(){
        // Increase the projectile speed of the basic spell by 10%
        basicSpell.projectileSpeed = basicSpell.projectileSpeed * 1.1f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
        WavePBS.SetActive(true);
        
        // Enable the Movement and Spell behaviors
        Movement.enabled = true;
        Spell.enabled = true;
    }

    public void PlayerMovimentSpeed01(){
        // Increase the player's movement speed by 10%
        playerMovement.runSpeed = playerMovement.runSpeed * 1.1f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
        WavePBS.SetActive(true);
        
        // Enable the Movement and Spell behaviors
        Movement.enabled = true;
        Spell.enabled = true;
    }

    public void playerLifesteal(){

        basicSpell.LifeSteal = basicSpell.LifeSteal + 0.1f;

        PowerUpHUD.SetActive(false);
        WavePBS.SetActive(true);
        
        Movement.enabled = true;
        Spell.enabled = true;
    }
}
