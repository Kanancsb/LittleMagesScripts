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

    public GameObject ImbuementHUD;
    public GameObject RerollHUD;
    public GameObject[] StatsHUD;

    public void FireDashButton(){
        StatsHUD[0].SetActive(true);
        firedash.firedash = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireballButton(){
        StatsHUD[1].SetActive(true);
        basicSpell.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbButton(){
        StatsHUD[2].SetActive(true);
        fireOrb.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireArmorButton(){
        StatsHUD[3].SetActive(true);
        fireArmor.FireArmorSpell = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }
}
