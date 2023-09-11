using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerKnowledge : MonoBehaviour
{
    
    public int Knowledge = 0;
    public int RefundKnowledge = 0;
    public int DamageLevel = 1;
    public int CDLevel = 1;
    public int SpellSpeedLevel = 1;
    public int PlayerHealthLevel = 1;
    public int ExtraLifeLevel = 1;
    public int RerollLevel = 1;
    public int ExtraSpellLevel = 1;
    public int CriticalChanceLevel = 1;
    public bool AutoShoot = false;

    void Awake(){
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
            AutoShoot = data.AutoShoot;
            Knowledge = data.Knowledge;
            RefundKnowledge = data.RefundKnowledge;
            DamageLevel = data.DamageLevel;
            CDLevel = data.CDLevel;
            SpellSpeedLevel = data.SpellSpeedLevel;
            PlayerHealthLevel = data.PlayerHealthLevel;
            ExtraLifeLevel = data.ExtraLifeLevel;
            RerollLevel = data.RerollLevel;
            ExtraSpellLevel = data.ExtraSpellLevel;
            CriticalChanceLevel = data.CriticalChanceLevel;
        }else{
            Debug.LogWarning("Failed to load player data. Using default values.");
        }
    }

    void Update(){
        if(Input.GetButtonDown("Pause")){
            SavePlayer();
        }else if(Input.GetButtonDown("Load")){
            LoadPlayer();
        }else if (Input.GetButtonDown("Delete")){
            // Define o save file path
            string path = Application.persistentDataPath + "/player.save";

            // Verifica se o arquivo de save existe antes de excluir
            if (File.Exists(path))
            {
                File.Delete(path);
                Debug.Log("Save file deleted.");
            }
            else
            {
                Debug.LogWarning("Save file not found. No file to delete.");
            }
        }
    }
}
