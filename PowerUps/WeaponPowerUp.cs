using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    
    public GameObject WeaponPowerUpHUD;
    public GameObject[] PowerUpButton;

    public GameObject[] Spell;
    public int SpellButton = 0;

    bool HUD = false;

    void FixedUpdate(){
        if(HUD){
            WeaponPowerUpHUD.SetActive(false);
            HUD = false;
        }
    }

    public void FireWheelSpell(){
        SpellButton++;
        Spell[0].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[0]);
    }

    public void FireMissile(){
        SpellButton++;
        Spell[1].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[1]);
    }
}
