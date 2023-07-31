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
    public int ExtraLifeLevel = 1;
    public int RerollLevel = 1;

    void Start(){
        LoadPlayer();
    }

    // Save the player's data
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    // Load the player's data from PlayerData Script
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null){
            Knowledge = data.Knowledge;
            DamageLevel = data.DamageLevel;
            CDLevel = data.CDLevel;
            SpellSpeedLevel = data.SpellSpeedLevel;
            PlayerHealthLevel = data.PlayerHealthLevel;
            ExtraLifeLevel = data.ExtraLifeLevel;
            RerollLevel = data.RerollLevel;
        }else{
            Debug.LogWarning("Failed to load player data. Using default values.");
        }
    }

    /*void Update(){
        if(Input.GetButtonDown("Pause")){
            SavePlayer();
        }else if(Input.GetButtonDown("Load")){
            LoadPlayer();
        }
    }*/
}
