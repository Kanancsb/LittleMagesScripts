using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnowledgeController : MonoBehaviour
{
    public PlayerKnowledge Lvls;

    public float MaxHealth = 100;
    public int ExtraLife;
    public int Roll;
    public float CritChance;
    public float CritDamage;

    void Start(){
        MaxHealth *= ((Lvls.PlayerHealthLevel - 1) * 0.1f) + 1f;
        ExtraLife = Lvls.ExtraLifeLevel - 1;
        Roll = Lvls.RerollLevel - 1;
        CritChance = ((Lvls.CriticalChanceLevel - 1) * 0.05f) + 0.1f;
        CritDamage = 2;
    }

}
