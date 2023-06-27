using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Knowledge;
    public int DamageLevel;
    public int CDLevel;
    public int SpellSpeedLevel;
    public int PlayerHealthLevel;

    // Constructor that takes a PlayerKnowledge object as a parameter
    public PlayerData(PlayerKnowledge player)
    {
        // Assign the knowledge value from the PlayerKnowledge object to the Knowledge field
        Knowledge = player.Knowledge;
        DamageLevel = player.DamageLevel;
        CDLevel = player.CDLevel;
        SpellSpeedLevel = player.SpellSpeedLevel;
        PlayerHealthLevel = player.PlayerHealthLevel;
    }
}
