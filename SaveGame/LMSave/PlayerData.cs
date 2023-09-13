using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Knowledge;
    public int RefundKnowledge;
    public int DamageLevel;
    public int CDLevel;
    public int SpellSpeedLevel;
    public int PlayerHealthLevel;
    public int ExtraLifeLevel;
    public int RerollLevel;
    public int ExtraSpellLevel;
    public int CriticalChanceLevel;
    public bool AutoShoot = false;
    public bool AquiredAutoShoot = false;

    // Constructor that takes a PlayerKnowledge object as a parameter
    public PlayerData(PlayerKnowledge player){
        // Assign the knowledge value from the PlayerKnowledge object to the Knowledge field
        AutoShoot = player.AutoShoot;
        AquiredAutoShoot = player.AquiredAutoShoot;
        RefundKnowledge = player.RefundKnowledge;
        Knowledge = player.Knowledge;
        DamageLevel = player.DamageLevel;
        CDLevel = player.CDLevel;
        SpellSpeedLevel = player.SpellSpeedLevel;
        PlayerHealthLevel = player.PlayerHealthLevel;
        ExtraLifeLevel = player.ExtraLifeLevel;
        RerollLevel = player.RerollLevel;
        ExtraSpellLevel = player.ExtraSpellLevel;
        CriticalChanceLevel = player.CriticalChanceLevel;
    }
}
