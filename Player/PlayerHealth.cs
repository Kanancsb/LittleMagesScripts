using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public float maxHealth = 100; // Set the max health
    public float currentHealth;
    public HealthBar healthBar; // calls the HealthBar Script

    public GameObject GameOverHUD;
    
    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // call the function SetMaxHealth of the HealthBar Script and set the int maxHealth
        GameOverHUD.SetActive(false);
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void FixedUpdate(){
        if(currentHealth <= 0){
            Destroy(gameObject);
            GameOverHUD.SetActive(true);
            Time.timeScale = 0;
        }else if(currentHealth > 100){
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

}
