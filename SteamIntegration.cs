using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{

    void Start(){
        try{
            Steamworks.SteamClient.Init(2560320);
            PrintYourName();
            //PrintFriends();
        }catch(System.Exception e){
            Debug.Log(e);
        }
    }

    public void UnlockAchievement(string id){
        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();
    }

    public void ClearAchievement(string id){
        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();
    }

    
    private void PrintYourName(){
        Debug.Log(Steamworks.SteamClient.Name);
    }

    private void PrintFriends(){
        foreach(var friend in Steamworks.SteamFriends.GetFriends()){
            Debug.Log(friend.Name);
        }
    }

    void Update(){
        Steamworks.SteamClient.RunCallbacks();
    }

    void OnApplicationQuit(){
        Steamworks.SteamClient.Shutdown();
    }
}
