using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImbuementLogic : MonoBehaviour
{
    public PlayerMovement firedash;
    public BasicSpell basicSpell;
    public FireOrb fireOrb;
    public PlayerHealth playerHealth;
    public FireArmor fireArmor;
    public FireGhost fireGhost;
    public MegaFireball megaFireball;
    public FireMissile fireMissile;

    public GameObject ImbuementHUD;
    public GameObject RerollHUD;
    public GameObject[] StatsHUD;
    public GameObject[] Button;

    public GameObject FireArmorImg;

    public void FireDashButton(){
        StatsHUD[0].SetActive(true);
        firedash.firedash = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[0]);
    }

    public void FireballButton(){
        StatsHUD[1].SetActive(true);
        basicSpell.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[1]);
    }

    public void FireOrbButton(){
        StatsHUD[2].SetActive(true);
        fireOrb.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[2]);
    }

    public void FireArmorButton(){
        StatsHUD[3].SetActive(true);
        fireArmor.FireArmorSpell = true;
        ImbuementHUD.SetActive(false);
        FireArmorImg.SetActive(true);
        RerollHUD.SetActive(false);
        Destroy(Button[3]);
    }

    public void MegaFireballButton(){
        StatsHUD[4].SetActive(true);
        megaFireball.imbuement = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[4]);
    }

    public void FireMissileButton(){
        StatsHUD[5].SetActive(true);
        fireMissile.Imbuement = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[5]);
    }

    public void FireGhost(){
        StatsHUD[6].SetActive(true);
        fireGhost.critDamage++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
        Destroy(Button[6]);
    }
}
