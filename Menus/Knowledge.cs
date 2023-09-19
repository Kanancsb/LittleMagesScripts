using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : MonoBehaviour
{
    public PlayerKnowledge playerKnowledge;
    public AncestralKnowledgeLogic akLogic;

    public void RefundButton(){
        playerKnowledge.Knowledge += playerKnowledge.RefundKnowledge;
        playerKnowledge.RefundKnowledge = 0;
        playerKnowledge.DamageLevel = 1;
        playerKnowledge.CDLevel = 1;
        playerKnowledge.SpellSpeedLevel = 1;
        playerKnowledge.PlayerHealthLevel = 1;
        playerKnowledge.ExtraLifeLevel = 1;
        playerKnowledge.RerollLevel = 1;
        playerKnowledge.ExtraSpellLevel = 1;
        playerKnowledge.CriticalChanceLevel = 1;
        foreach (GameObject Hud in akLogic.HUD){
            Hud.SetActive(false);
        }
        playerKnowledge.SavePlayer();
    }
}
