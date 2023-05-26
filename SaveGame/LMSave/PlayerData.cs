using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    
    public int Knowledge;

    public PlayerData(PlayerKnowledge player){
        Knowledge = player.Knowledge;
    }
}
