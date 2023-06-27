using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBomb : MonoBehaviour
{

    public PlayerKnowledge Lvls;
    
    public bool ActiveLB = false;

    public float Timer = 5;
    public float damage = 10f;
    public float BombChance = 0.1f;
    public float LifeSteal = 0;

    public bool LVChosen = false;

    void Start(){
        damage *= (Lvls.DamageLevel * 0.05f) + 1f;
    }
}
