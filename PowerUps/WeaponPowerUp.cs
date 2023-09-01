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

    public GameObject[] StatsHUD;
    public GameObject[] StatsCont;

    bool HUD = false;

    void FixedUpdate(){
        if(HUD){
            WeaponPowerUpHUD.SetActive(false);
            HUD = false;
        }
    }

    public void FireWheelSpell(){
        StatsHUD[0].SetActive(true);
        StatsCont[0].SetActive(true);
        SpellButton++;
        Spell[0].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[0]);
        RerollHUD.SetActive(false);
    }

    public void FireMissile(){
        StatsHUD[1].SetActive(true);
        StatsCont[1].SetActive(true);
        SpellButton++;
        Spell[1].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[1]);
        RerollHUD.SetActive(false);
    }

    public void MegaFireball(){
        StatsHUD[2].SetActive(true);
        StatsCont[2].SetActive(true);
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
        StatsHUD[3].SetActive(true);
        StatsCont[3].SetActive(true);
        Spell[4].SetActive(true);
        fireOrb.FOChosen = true;
        HUD = true;
        Destroy(PowerUpButton[4]);
        RerollHUD.SetActive(false);
    }

    public void FireGhost(){
        StatsHUD[4].SetActive(true);
        StatsCont[4].SetActive(true);
        SpellButton++;
        Spell[5].SetActive(true); 
        HUD = true;
        Destroy(PowerUpButton[5]);
        RerollHUD.SetActive(false);
    }
}
