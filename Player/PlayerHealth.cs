using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public PlayerKnowledge Lvls;
    
    public float maxHealth = 100; // Set the max health
    public float currentHealth;
    public HealthBar healthBar;

    public int PlayerLifes;

    public GameObject GameOverHUD;
    
    void Start(){
        maxHealth *= ((Lvls.PlayerHealthLevel - 1) * 0.1f) + 1f;
        PlayerLifes = Lvls.ExtraLifeLevel;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // call the function SetMaxHealth of the HealthBar Script and set the int maxHealth
        GameOverHUD.SetActive(false);
    }

    void FixedUpdate(){
        if(currentHealth <= 0){
            PlayerDeath();
        }else if(currentHealth > 100){
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
            PlayerLifes--;
        }
    }

}
