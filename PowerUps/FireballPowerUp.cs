using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject PowerUpHUD;
    public GameObject RerollHUD;

    public void FireballPowerUpDamage01(){
        basicSpell.damage += 5;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireballPowerUpCD01(){
        basicSpell.CastCD = basicSpell.CastCD * 0.85f;
        basicSpell.projectileSpeed = basicSpell.projectileSpeed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void PlayerMovimentSpeed01(){
        playerMovement.runSpeed = playerMovement.runSpeed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void playerLifesteal(){

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
        fireWheelSpell.damage = fireWheelSpell.damage * 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireWheelPowerUpCD(){
        fireWheelSpell.CastCD = fireWheelSpell.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpDamage(){
        fireMissile.damage = fireMissile.damage * 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpCD(){
        fireMissile.CastCD = fireMissile.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpDamage(){
        megaFireball.damage = megaFireball.damage * 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpCD(){
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
        fireOrb.damage = fireOrb.damage * 1.1f;
        fireOrb.radius *= 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbPowerUpCD(){
        fireOrb.Cooldown = fireOrb.Cooldown * 0.85f;
        fireOrb.speed = fireOrb.speed * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void CriticalChancePowerUp(){
        Lvls.CritChance += 0.05f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireGhostPowerUp(){
        fireGhost.damage *= 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireGhostCDPowerUp(){
        fireGhost.CastCD *= 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }
}