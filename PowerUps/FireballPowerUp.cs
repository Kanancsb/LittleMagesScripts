using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballPowerUp : MonoBehaviour
{
    public SteamIntegration integration;
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

    public int[] AchDMG;
    public int[] AchCD;

    void OnEnable(){
        integration = FindObjectOfType<SteamIntegration>();
    }

    void AchDamageLogic(int n){
        AchDMG[n]++;
        if(AchDMG[n] == 10){
            integration.UnlockAchievement("ACH_BuyDMG");
        }
    }

    void AchCDLogic(int n){
        AchCD[n]++;
        if(AchCD[n] == 10){
            integration.UnlockAchievement("ACH_BuyCD");
        }
    }

    public void FireballPowerUpDamage01(){
        AchDamageLogic(0);
        StatsCont[0].text += "+";
        basicSpell.damage += 5;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireballPowerUpCD01(){
        AchCDLogic(0);
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
        AchDamageLogic(1);
        StatsCont[4].text += "+";
        fireWheelSpell.damage = fireWheelSpell.damage * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireWheelPowerUpCD(){
        AchCDLogic(1);
        StatsCont[5].text += "+";
        fireWheelSpell.CastCD = fireWheelSpell.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpDamage(){
        AchDamageLogic(2);
        StatsCont[6].text += "+";
        fireMissile.damage = fireMissile.damage * 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireMissilePowerUpCD(){
        AchCDLogic(2);
        StatsCont[7].text += "+";
        fireMissile.CastCD = fireMissile.CastCD * 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpDamage(){
        AchDamageLogic(3);
        StatsCont[8].text += "+";
        megaFireball.damage = megaFireball.damage * 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void MegaFireballPowerUpCD(){
        AchCDLogic(3);
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
        AchDamageLogic(4);
        StatsCont[10].text += "+";
        fireOrb.damage = fireOrb.damage * 1.1f;
        fireOrb.radius *= 1.1f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireOrbPowerUpCD(){
        AchCDLogic(4);
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
        AchDamageLogic(5);
        StatsCont[13].text += "+";
        fireGhost.damage *= 1.2f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }

    public void FireGhostCDPowerUp(){
        AchCDLogic(5);
        StatsCont[14].text += "+";
        fireGhost.CastCD *= 0.85f;
        PowerUpHUD.SetActive(false);
        RerollHUD.SetActive(false);
    }
}