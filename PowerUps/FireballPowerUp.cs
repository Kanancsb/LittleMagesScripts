using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballPowerUp : MonoBehaviour
{
    // Scripts needed
    public BasicSpell basicSpell;
    public FireWheelSpell fireWheelSpell;
    public FireMissile fireMissile;
    public MegaFireball megaFireball;
    public LivingBomb livingBomb;
    public FireOrb fireOrb;
    public FireGhost fireGhost;
    public PlayerKnowledgeController Lvls;
    
    public PlayerMovement playerMovement;

    public TMP_Text[] StatsCont;

    public GameObject PowerUpHUD;
    public GameObject RerollHUD;

    public void FireballPowerUpDamage01(){
        StatsCont[0].text += "+";
        basicSpell.damage += 5;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireballPowerUpCD01(){
        StatsCont[1].text += "+";
        basicSpell.CastCD = basicSpell.CastCD * 0.85f;
        basicSpell.projectileSpeed = basicSpell.projectileSpeed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void PlayerMovimentSpeed01(){
        StatsCont[2].text += "+";
        playerMovement.originalrunSpeed = playerMovement.originalrunSpeed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void playerLifesteal(){
        StatsCont[3].text += "+";
        basicSpell.LifeSteal = basicSpell.LifeSteal + 0.02f;
        fireWheelSpell.LifeSteal = fireWheelSpell.LifeSteal + 0.02f;
        fireMissile.LifeSteal = fireMissile.LifeSteal + 0.02f;
        megaFireball.LifeSteal = fireMissile.LifeSteal + 0.02f;
        livingBomb.LifeSteal = livingBomb.LifeSteal + 0.02f;
        fireOrb.LifeSteal = fireOrb.LifeSteal + 0.02f;

        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireWheelPowerUpDamage(){
        StatsCont[4].text += "+";
        fireWheelSpell.damage = fireWheelSpell.damage * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireWheelPowerUpCD(){
        StatsCont[5].text += "+";
        fireWheelSpell.CastCD = fireWheelSpell.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpDamage(){
        StatsCont[6].text += "+";
        fireMissile.damage = fireMissile.damage * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpCD(){
        StatsCont[7].text += "+";
        fireMissile.CastCD = fireMissile.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpDamage(){
        StatsCont[8].text += "+";
        megaFireball.damage = megaFireball.damage * 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpCD(){
        StatsCont[9].text += "+";
        megaFireball.CastCD = megaFireball.CastCD * 0.85f;
        megaFireball.projectileSpeed = megaFireball.projectileSpeed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void LivingBombPowerUpDamage(){
        livingBomb.damage = livingBomb.damage * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void LivingBombPowerUpChance(){
        livingBomb.BombChance = livingBomb.BombChance + 0.05f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbPowerUpDamage(){
        StatsCont[10].text += "+";
        fireOrb.damage = fireOrb.damage * 1.1f;
        fireOrb.radius *= 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbPowerUpCD(){
        StatsCont[11].text += "+";
        fireOrb.Cooldown = fireOrb.Cooldown * 0.85f;
        fireOrb.speed = fireOrb.speed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void CriticalChancePowerUp(){
        StatsCont[12].text += "+";
        Lvls.CritChance += 0.05f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireGhostPowerUp(){
        StatsCont[13].text += "+";
        fireGhost.damage *= 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireGhostCDPowerUp(){
        StatsCont[14].text += "+";
        fireGhost.CastCD *= 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }
}