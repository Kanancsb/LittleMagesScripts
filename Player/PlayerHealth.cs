using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 100; // Set the max health
    public int currentHealth;
    public HealthBar healthBar; // calls the HealthBar Script
    
    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // call the function SetMaxHealth of the HealthBar Script and set the int maxHealth
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Update(){
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
