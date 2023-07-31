using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AncestralKnowledgeLogic : MonoBehaviour
{

    public PlayerKnowledge knowledge;

    public GameObject[] HUD;

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
            { 3, 50000 },
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

    public void SaveButton(){
        knowledge.SavePlayer();
    }
    
    // Damage Upgrade
    public void DamageButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[0].SetActive(true);
    }

    public void LearnDamage(){ 
        if(knowledge.Knowledge >= DamageCost){
            knowledge.Knowledge -= DamageCost;
            knowledge.DamageLevel++;
        }
    }
    // ---- !

    // Cooldown Upgrade
    public void CDButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[1].SetActive(true);
    }

    public void LearnCD(){ 
        if(knowledge.Knowledge >= CDCost){
            knowledge.Knowledge -= CDCost;
            knowledge.CDLevel++;
        }
    }
    // ---- !

    // Speed Upgrade
    public void SpellSpeedButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[2].SetActive(true);
    }

    public void LearnSpellSpeed(){ 
        if(knowledge.Knowledge >= SSCost){
            knowledge.Knowledge -= SSCost;
            knowledge.SpellSpeedLevel++;
        }
    }

    // ---- !

    // Health Upgrade
    public void PlayerHealthButton(){
        foreach (GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[3].SetActive(true);
    }

    public void LearnPlayerHealth(){ 
        if(knowledge.Knowledge >= PlayerHealthCost){
            knowledge.Knowledge -= PlayerHealthCost;
            knowledge.PlayerHealthLevel++;
        }
    }

    // ---- !

    // Life Upgrade
    public void PlayerLifeButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[4].SetActive(true);
    }

    public void LearnExtraLife(){
        if(knowledge.Knowledge >= ExtraLifeCost){
            knowledge.Knowledge -= ExtraLifeCost;
            knowledge.ExtraLifeLevel++;
        }
    }

    // ---- !

    // Reroll Upgrade
    public void RerollButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[5].SetActive(true);
    }

    public void LearnReroll(){
        if(knowledge.Knowledge >= RerollCost){
            knowledge.Knowledge -= RerollCost;
            knowledge.RerollLevel++;
        }
    }

    // ---- !

    // Extra Spell Upgrade
    public void ExtraSpellButton(){
        foreach(GameObject Hud in HUD){
            Hud.SetActive(false);
        }
        HUD[6].SetActive(true);
    }

    public void LearnExtraSpell(){
        if(knowledge.Knowledge >= ExtraSpellCost){
            knowledge.Knowledge -= ExtraSpellCost;
            knowledge.ExtraSpellLevel++;
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
    }

}
