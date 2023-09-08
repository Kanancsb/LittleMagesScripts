using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public PlayerKnowledge SaveStats;
    public PlayerKnowledgeController ControllerStats;
    public PlayerMovement MovementStats;
    public PlayerHealth HealthStats;
    public BasicSpell basicSpell;

    public TMP_Text MaxHealtText;
    public TMP_Text MovSpeedText;
    public TMP_Text CritChanceText;
    public TMP_Text CritDamageText;
    public TMP_Text LifeStealText;

    void OnEnable(){
        float critchance = ControllerStats.CritChance * 100;
        float lifesteal = basicSpell.LifeSteal * 100;
        MaxHealtText.text = "Max Health: " + HealthStats.maxHealth;
        MovSpeedText.text = "Moviment Speed: " + MovementStats.runSpeed;
        CritChanceText.text = "Critical Chance: " + Mathf.RoundToInt(critchance) + "%";
        CritDamageText.text = "Critical Multiplier: " + ControllerStats.CritDamage;
        LifeStealText.text = "LifeSteal: " + lifesteal + "%";

    }
}
