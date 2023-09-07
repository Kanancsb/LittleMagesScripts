using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    public LivingBomb livingBomb;
    public FireOrb fireOrb;
    public FireWheelSpell fireWheelSpell;
    public FireGhost fireGhost;
    public FireMissile fireMissile;
    public MegaFireball megaFireball;
    
    public GameObject WeaponPowerUpHUD;
    public GameObject[] PowerUpButton;

    public GameObject[] Spell;
    public int SpellButton = 0;

    public GameObject RerollHUD;

    public GameObject[] StatsHUD;
    public GameObject[] StatsCont;

    public void FireWheelSpell(){
        RerollHUD.SetActive(false);
        StatsHUD[0].SetActive(true);
        StatsCont[0].SetActive(true);
        SpellButton++;
        Spell[0].SetActive(true);
        fireWheelSpell.FWChosen = true; 
        fireWheelSpell.IChosen = true; 
        Destroy(PowerUpButton[0]);
        WeaponPowerUpHUD.SetActive(false);
    }

    public void FireMissile(){
        StatsHUD[1].SetActive(true);
        StatsCont[1].SetActive(true);
        SpellButton++;
        Spell[1].SetActive(true); 
        fireMissile.FMChosen = true;
        fireMissile.IChosen = true;
        RerollHUD.SetActive(false);
        Destroy(PowerUpButton[1]);
        WeaponPowerUpHUD.SetActive(false);
    }

    public void MegaFireball(){
        StatsHUD[2].SetActive(true);
        StatsCont[2].SetActive(true);
        SpellButton++;
        Spell[2].SetActive(true); 
        megaFireball.MFChosen = true;
        megaFireball.IChosen = true;
        RerollHUD.SetActive(false);
        Destroy(PowerUpButton[2]);
        WeaponPowerUpHUD.SetActive(false);
    }

    /*public void LivingBomb(){
        livingBomb.ActiveLB = true;
        livingBomb.LVChosen = true;
        Spell[3].SetActive(true); 
        Destroy(PowerUpButton[3]);
        RerollHUD.SetActive(false);
    }*/

    public void FireOrb(){
        StatsHUD[3].SetActive(true);
        StatsCont[3].SetActive(true);
        Spell[3].SetActive(true);
        fireOrb.FOChosen = true;
        fireOrb.IChosen = true;
        RerollHUD.SetActive(false);
        Destroy(PowerUpButton[4]);
        WeaponPowerUpHUD.SetActive(false);
    }

    public void FireGhost(){
        StatsHUD[4].SetActive(true);
        StatsCont[4].SetActive(true);
        SpellButton++;
        Spell[4].SetActive(true); 
        fireGhost.FGChosen = true;
        fireGhost.IChosen = true;
        RerollHUD.SetActive(false);
        Destroy(PowerUpButton[5]);
        WeaponPowerUpHUD.SetActive(false);
    }
}
