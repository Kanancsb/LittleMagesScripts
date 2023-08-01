using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    public LivingBomb livingBomb;
    public FireOrb fireOrb;
    
    public GameObject WeaponPowerUpHUD;
    public GameObject[] PowerUpButton;

    public GameObject[] Spell;
    public int SpellButton = 0;

    public GameObject RerollHUD;

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
        RerollHUD.SetActive(false);
    }

    public void FireMissile(){
        SpellButton++;
        Spell[1].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[1]);
        RerollHUD.SetActive(false);
    }

    public void MegaFireball(){
        SpellButton++;
        Spell[2].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[2]);
        RerollHUD.SetActive(false);
    }

    public void LivingBomb(){
        livingBomb.ActiveLB = true;
        livingBomb.LVChosen = true;
        Spell[3].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[3]);
        RerollHUD.SetActive(false);
    }

    public void FireOrb(){
        fireOrb.FOChosen = true;
        Spell[4].SetActive(true);
        HUD = true;
        Destroy(PowerUpButton[4]);
        RerollHUD.SetActive(false);
    }
}
