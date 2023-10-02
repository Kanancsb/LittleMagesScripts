using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverLogic : MonoBehaviour
{

    public BasicSpell basicSpell;
    public FireGhost fireGhost;
    public FireMissile fireMissile;
    public FireOrb fireOrb;
    public FireWheelSpell fireWheel;
    public MegaFireball megaFireball;
    public FireArmor fireArmor;

    public TMP_Text[] SpellText;

    void OnEnable(){
        SpellText[0].text = "Damage dealt: " + basicSpell.DamageCont;
        SpellText[1].text = "Damage dealt: " + fireGhost.DamageCont;
        SpellText[2].text = "Damage dealt: " + fireMissile.DamageCont;
        SpellText[3].text = "Damage dealt: " + fireOrb.DamageCont;
        SpellText[6].text = "Enemy spells destroied: " + fireOrb.DestroyCont;
        SpellText[4].text = "Damage dealt: " + fireWheel.DamageCont;
        SpellText[5].text = "Damage dealt: " + megaFireball.DamageCont;
        SpellText[7].text = "Damage dealt: " + fireArmor.cont;
    }
}
