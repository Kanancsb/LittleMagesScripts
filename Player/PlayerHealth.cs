using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public PlayerKnowledge Lvl;
    public BasicSpell Lvls;
    
    public float maxHealth = 100; // Set the max health
    public float currentHealth;
    public HealthBar healthBar;

    public int PlayerLifes;

    public GameObject GameOverHUD;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // call the function SetMaxHealth of the HealthBar Script and set the int maxHealth
        GameOverHUD.SetActive(false);
    }

    void FixedUpdate(){
        maxHealth = Lvls.MaxHealth;
        PlayerLifes = Lvls.ExtraLife;
        if(currentHealth <= 0){
            PlayerDeath();
        }else if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OverTimeDamage(float damage, float time, bool burn){
        if (burn){
            StartCoroutine(ApplyOverTimeDamage(damage, time));
        }
    }

    private IEnumerator ApplyOverTimeDamage(float damage, float time){
        float elapsedTime = 0f;

        while (elapsedTime < time){
            TakeDamage(damage);
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }
    }

    //Player Death Function
    public void PlayerDeath(){
        if(PlayerLifes < 1){
            Destroy(gameObject);
            GameOverHUD.SetActive(true);
            Time.timeScale = 0;
        }else{
            currentHealth = 50;
            Lvls.ExtraLife--;
        }
    }

}
