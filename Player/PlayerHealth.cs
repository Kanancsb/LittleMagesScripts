using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public float maxHealth = 100; // Set the max health
    public float currentHealth;
    public HealthBar healthBar; // calls the HealthBar Script
    
    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // call the function SetMaxHealth of the HealthBar Script and set the int maxHealth
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Update(){
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
