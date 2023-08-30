using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellStats : MonoBehaviour
{
    public PlayerKnowledge SaveStats;

    public BasicSpell basicSpell;
    public TMP_Text[] FireballText;
    public GameObject FireballHud;

    public FireGhost fireGhost;
    public TMP_Text[] FireGhostText;

    public FireMissile fireMissile;
    public TMP_Text[] FireMissileText;

    public FireOrb fireOrb;
    public TMP_Text[] FireOrbText;

    public FireWheelSpell fireWheel;
    public TMP_Text[] FireWheelText;

    public MegaFireball megaFireball;
    public TMP_Text[] MegaFireballText;

    public void FireballStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, BasicSpell spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.CastCD;
        Speed.text = "Projectile Speed: " + spell.projectileSpeed;

    }

    public void FireGhostStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, FireGhost spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.CastCD;
        Speed.text = "Projectile Speed: " + spell.projectileSpeed;
    }

    public void FireMissileStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, FireMissile spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.CastCD;
        Speed.text = "Projectile Speed: " + spell.projectileSpeed;
    }

    public void FireOrbStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, FireOrb spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.Cooldown;
        Speed.text = "Projectile Speed: " + spell.speed;
    }

    public void FireWheelStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, FireWheelSpell spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.CastCD;
        Speed.text = "Projectile Speed: " + spell.projectileSpeed;
    }

    public void MegaFireballStats(TMP_Text Damage, TMP_Text CD, TMP_Text Speed, MegaFireball spell){
        float calculatedDamage = spell.damage * ((SaveStats.DamageLevel - 1) * 0.05f) + spell.damage;
        Damage.text = "Damage: " + calculatedDamage;
        CD.text = "Cooldown: " + spell.CastCD;
        Speed.text = "Projectile Speed: " + spell.projectileSpeed;
    }

    void OnEnable(){
        FireballStats(FireballText[0], FireballText[1], FireballText[2], basicSpell);
        FireGhostStats(FireGhostText[0], FireGhostText[1], FireGhostText[2], fireGhost);
        FireMissileStats(FireMissileText[0], FireMissileText[1], FireMissileText[2], fireMissile);
        FireOrbStats(FireOrbText[0], FireOrbText[1], FireOrbText[2], fireOrb);
        FireWheelStats(FireWheelText[0], FireWheelText[1], FireWheelText[2], fireWheel);
        MegaFireballStats(MegaFireballText[0], MegaFireballText[1], MegaFireballText[2], megaFireball);
    }

}
