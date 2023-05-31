using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPowerUp : MonoBehaviour
{
    // Reference to the BasicSpell script
    public BasicSpell basicSpell;
    public FireWheelSpell fireWheelSpell;
    public FireMissile fireMissile;
    
    // Reference to the PlayerMovement script
    public PlayerMovement playerMovement;

    // Reference to the PowerUpHUD game object
    public GameObject PowerUpHUD;

    public void FireballPowerUpDamage01(){
        // Increase the damage of the basic spell by 5
        basicSpell.damage = basicSpell.damage + 5;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
    }

    public void FireballPowerUpCD01(){
        // Decrease the cast cooldown of the basic spell by 10%
        basicSpell.CastCD = basicSpell.CastCD * 0.9f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
    }

    public void FireballPowerUpSpeed01(){
        // Increase the projectile speed of the basic spell by 10%
        basicSpell.projectileSpeed = basicSpell.projectileSpeed * 1.1f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
    }

    public void PlayerMovimentSpeed01(){
        // Increase the player's movement speed by 10%
        playerMovement.runSpeed = playerMovement.runSpeed * 1.1f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
    }

    public void playerLifesteal(){

        basicSpell.LifeSteal = basicSpell.LifeSteal + 0.1f;
        fireWheelSpell.LifeSteal = fireWheelSpell.LifeSteal + 0.1f;
        fireMissile.LifeSteal = fireMissile.LifeSteal + 0.1f;


        PowerUpHUD.SetActive(false);
    }

    public void FireWheelPowerUpDamage(){

        fireWheelSpell.damage = fireWheelSpell.damage * 1.2f;

        PowerUpHUD.SetActive(false);
    }

    public void FireWheelPowerUpCD(){
        // Decrease the cast cooldown of the basic spell by 10%
        fireWheelSpell.CastCD = fireWheelSpell.CastCD * 0.9f;
        
        // Deactivate the PowerUpHUD and Active WavePBS
        PowerUpHUD.SetActive(false);
    }
}