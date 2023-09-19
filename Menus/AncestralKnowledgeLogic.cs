using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AncestralKnowledgeLogic : MonoBehaviour
{

    public PlayerKnowledge knowledge;

    public GameObject[] HUD;

    // Audio Logic
    public AudioSource DeniedSound;
    public AudioSource BuySound;

    // Buy Ancestral Knowledge Logic
    public int DamageCost;
    public TMP_Text DamageLevelText;
    public TMP_Text DamageCostText;

    public int CDCost;
    public TMP_Text CDLevelText;
    public TMP_Text CDCostText;

    public int SSCost;
    public TMP_Text SSLevelText;
    public TMP_Text SSCostText;

    public int PlayerHealthCost;
    public TMP_Text PlayerHealthLevelText;
    public TMP_Text PlayerHealthCostText;

    public int ExtraLifeCost;
    public TMP_Text ExtraLifeLevelText;
    public TMP_Text ExtraLifeCostText;

    public int RerollCost;
    public TMP_Text RerollLevelText;
    public TMP_Text RerollCostText;

    public int ExtraSpellCost;
    public TMP_Text ExtraSpellLevelText;
    public TMP_Text ExtraSpellCostText;

    public int CriticalChanceCost;
    public TMP_Text CriticalChanceLevelText;
    public TMP_Text CriticalChanceCostText;

    // Costs Logic
    Dictionary<int, int> levelCosts = new Dictionary<int, int>()
        {
            { 1, 200 },
            { 2, 1000 },
            { 3, 5000 },
            { 4, 10000 },
            { 5, 50000 }
        };
    
    Dictionary<int, int> levelCostsExtraLife = new Dictionary<int, int>()
        {
            { 1, 5000 },
            { 2, 20000 },
        };

    Dictionary<int, int> levelCostReroll = new Dictionary<int, int>()
        {
            { 1, 2000 },
            { 2, 10000 },
            { 3, 30000 },
        };

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
        DamageLevelText.text = "Level: " + knowledge.DamageLevel;
        CDLevelText.text = "Level: " + knowledge.CDLevel;
        SSCostText.text = "Level: " + knowledge.SpellSpeedLevel;
        PlayerHealthCostText.text = "Level: " + knowledge.PlayerHealthLevel;
        ExtraLifeCostText.text = "Level: " + knowledge.ExtraLifeLevel;
        RerollCostText.text = "Level: " + knowledge.RerollLevel;
        ExtraSpellCostText.text = "Level: " + knowledge.ExtraSpellLevel;
    }
    
    // Damage Upgrade
    public void DamageButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.DamageLevel > 5){
            HUD[8].SetActive(true);
        }else{
            HUD[0].SetActive(true);
        }
    }

    public void LearnDamage(){ 
        if(knowledge.Knowledge >= DamageCost){
            knowledge.Knowledge -= DamageCost;
            knowledge.RefundKnowledge += DamageCost;
            knowledge.DamageLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.DamageLevel > 5){
                HUD[0].SetActive(false);
                HUD[8].SetActive(true);
            }
        }
        else{
            DeniedSound.Play();
        }
    }
    // ---- !

    // Cooldown Upgrade
    public void CDButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.CDLevel > 5){
            HUD[1].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[1].SetActive(true);    
        }
    }

    public void LearnCD(){ 
        if(knowledge.Knowledge >= CDCost){
            knowledge.Knowledge -= CDCost;
            knowledge.RefundKnowledge += CDCost;
            knowledge.CDLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.CDLevel > 5){
                HUD[1].SetActive(false);
                HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }
    // ---- !

    // Speed Upgrade
    public void SpellSpeedButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.SpellSpeedLevel > 5){
            HUD[2].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[2].SetActive(true);    
        }
    }

    public void LearnSpellSpeed(){ 
        if(knowledge.Knowledge >= SSCost){
            knowledge.Knowledge -= SSCost;
            knowledge.RefundKnowledge += SSCost;
            knowledge.SpellSpeedLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.SpellSpeedLevel > 5){
                HUD[2].SetActive(false);
                HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    // Health Upgrade
    public void PlayerHealthButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.PlayerHealthLevel > 5){
            HUD[3].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[3].SetActive(true);    
        }
    }

    public void LearnPlayerHealth(){ 
        if(knowledge.Knowledge >= PlayerHealthCost){
            knowledge.Knowledge -= PlayerHealthCost;
            knowledge.RefundKnowledge += PlayerHealthCost;
            knowledge.PlayerHealthLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.PlayerHealthLevel > 5){
                HUD[3].SetActive(false);
                HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    // Life Upgrade
    public void PlayerLifeButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.ExtraLifeLevel > 2){
            HUD[4].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[4].SetActive(true);    
        }
        
    }

    public void LearnExtraLife(){
        if(knowledge.Knowledge >= ExtraLifeCost){
            knowledge.Knowledge -= ExtraLifeCost;
            knowledge.RefundKnowledge += ExtraLifeCost;
            knowledge.ExtraLifeLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.ExtraLifeLevel > 2){
                HUD[4].SetActive(false);
                HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    // Reroll Upgrade
    public void RerollButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.RerollLevel > 3){
            HUD[5].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[5].SetActive(true);    
        }
    }

    public void LearnReroll(){
        if(knowledge.Knowledge >= RerollCost){
            knowledge.Knowledge -= RerollCost;
            knowledge.RefundKnowledge += RerollCost;
            knowledge.RerollLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    // Extra Spell Upgrade
    public void ExtraSpellButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.ExtraSpellLevel > 2){
            HUD[6].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[6].SetActive(true);    
        }
    }

    public void LearnExtraSpell(){
        if(knowledge.Knowledge >= ExtraSpellCost){
            knowledge.Knowledge -= ExtraSpellCost;
            knowledge.RefundKnowledge += ExtraSpellCost;
            knowledge.ExtraSpellLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.ExtraSpellLevel > 2){
            HUD[6].SetActive(false);
            HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    // Critical Chance Upgrade
    public void CriticalChanceButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        if(knowledge.CriticalChanceLevel > 5){
            HUD[7].SetActive(false);
            HUD[8].SetActive(true);
        }else{
            HUD[7].SetActive(true);    
        }
    }

    public void LearnCriticalChance(){
        if(knowledge.Knowledge >= CriticalChanceCost){
            knowledge.Knowledge -= CriticalChanceCost;
            knowledge.RefundKnowledge += CriticalChanceCost;
            knowledge.CriticalChanceLevel++;
            BuySound.Play();
            knowledge.SavePlayer();
            if(knowledge.CriticalChanceLevel > 5){
            HUD[7].SetActive(false);
            HUD[8].SetActive(true);
            }
        }else{
            DeniedSound.Play();
        }
    }

    // ---- !

    public void Update(){
        DamageLevelText.text = "Level: " + knowledge.DamageLevel;
        CDLevelText.text = "Level: " + knowledge.CDLevel;
        SSLevelText.text = "Level: " + knowledge.SpellSpeedLevel;
        PlayerHealthLevelText.text = "Level: " + knowledge.PlayerHealthLevel;
        ExtraLifeLevelText.text = "Level: " + knowledge.ExtraLifeLevel;
        RerollLevelText.text = "Level: " + knowledge.RerollLevel;
        ExtraSpellLevelText.text = "Level: " + knowledge.ExtraSpellLevel;
        CriticalChanceLevelText.text = "Level: " + knowledge.CriticalChanceLevel;

        if (levelCosts.TryGetValue(knowledge.CDLevel, out int cdCost)){
            CDCost = cdCost;
            CDCostText.text = "Cost: " + CDCost;
        }

        if (levelCosts.TryGetValue(knowledge.DamageLevel, out int damageCost)){
            DamageCost = damageCost;
            DamageCostText.text = "Cost: " + DamageCost;
        }

        if (levelCosts.TryGetValue(knowledge.SpellSpeedLevel, out int ssCost)){
            SSCost = ssCost;
            SSCostText.text = "Cost: " + SSCost;
        }

        if (levelCosts.TryGetValue(knowledge.PlayerHealthLevel, out int phCost)){
            PlayerHealthCost = phCost;
            PlayerHealthCostText.text = "Cost: " + PlayerHealthCost;
        }

        if (levelCostsExtraLife.TryGetValue(knowledge.ExtraLifeLevel, out int elCost)){
            ExtraLifeCost = elCost;
            ExtraLifeCostText.text = "Cost: " + ExtraLifeCost;
        }

        if (levelCostReroll.TryGetValue(knowledge.RerollLevel, out int reCost)){
            RerollCost = reCost;
            RerollCostText.text = "Cost: " + RerollCost;
        }

        if (levelCostsExtraLife.TryGetValue(knowledge.ExtraSpellLevel, out int esCost)){
            ExtraSpellCost = esCost;
            ExtraSpellCostText.text = "Cost: " + ExtraSpellCost;
        }

        if(levelCosts.TryGetValue(knowledge.CriticalChanceLevel, out int ccCost)){
            CriticalChanceCost = ccCost;
            CriticalChanceCostText.text = "Cost: " + CriticalChanceCost;
        }
    }

}
