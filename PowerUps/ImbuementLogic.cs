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

    public void FireDashButton(){
        firedash.firedash = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireballButton(){
        basicSpell.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbButton(){
        fireOrb.SpellResist++;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireArmorButton(){
        fireArmor.FireArmorSpell = true;
        ImbuementHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }
}
