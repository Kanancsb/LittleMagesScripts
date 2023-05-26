using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnowledge : MonoBehaviour
{
    
    public int Knowledge = 0;

    void Start(){
        LoadPlayer();
    }

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        Knowledge = data.Knowledge;
    }

    void Update(){
        if(Input.GetButtonDown("Pause")){
            SavePlayer();
        }else if(Input.GetButtonDown("Load")){
            LoadPlayer();
        }
    }
}
