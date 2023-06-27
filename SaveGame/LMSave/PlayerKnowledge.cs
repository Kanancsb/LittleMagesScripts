using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnowledge : MonoBehaviour
{
    
    public int Knowledge = 0;
    public int DamageLevel = 1;
    public int CDLevel = 1;
    public int SpellSpeedLevel = 1;
    public int PlayerHealthLevel = 1;

    void Start(){
        LoadPlayer();
    }

    // Save the player's data
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    // Load the player's data
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        Knowledge = data.Knowledge;
        DamageLevel = data.DamageLevel;
        CDLevel = data.CDLevel;
        SpellSpeedLevel = data.SpellSpeedLevel;
        PlayerHealthLevel = data.PlayerHealthLevel;
    }

    void Update(){
        if(Input.GetButtonDown("Pause")){
            SavePlayer();
        }else if(Input.GetButtonDown("Load")){
            LoadPlayer();
        }
    }
}
