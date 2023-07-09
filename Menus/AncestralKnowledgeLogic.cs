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

    Dictionary<int, int> levelCosts = new Dictionary<int, int>()
        {
            { 1, 200 },
            { 2, 1000 },
            { 3, 5000 },
            { 4, 10000 },
            { 5, 50000 }
        };

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
        DamageLevelText.text = "Level: " + knowledge.DamageLevel;
        CDLevelText.text = "Level: " + knowledge.CDLevel;
        SSCostText.text = "Level: " + knowledge.SpellSpeedLevel;
        PlayerHealthCostText.text = "Level: " + knowledge.PlayerHealthLevel;
    }

    public void SaveButton(){
        knowledge.SavePlayer();
    }
    
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

    public void FixedUpdate(){
        DamageLevelText.text = "Level: " + knowledge.DamageLevel;
        CDLevelText.text = "Level: " + knowledge.CDLevel;
        SSLevelText.text = "Level: " + knowledge.SpellSpeedLevel;
        PlayerHealthLevelText.text = "Level: " + knowledge.PlayerHealthLevel;

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
    }

}
