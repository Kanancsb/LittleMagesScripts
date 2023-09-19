using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArmorProc : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public FireArmor fireArmor;

    public float Health;

    void Start(){
        Health = playerHealth.currentHealth;
    }
    // Update is called once per frame
    void Update(){
        if(playerHealth.currentHealth < Health){
            float damage = Health - playerHealth.currentHealth;
            Health = playerHealth.currentHealth;
            fireArmor.Backslash(damage);
        }
        Health = playerHealth.currentHealth;
    }
}
