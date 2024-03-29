using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public PlayerKnowledge Lvls;
    public Enemy enemy;
    
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    public int PlayerLifes;

    public GameObject GameOverHUD;

    public bool FireArmor = false;
    public float FireArmorDamage = 0.5f;

    void Start(){
        maxHealth *= ((Lvls.PlayerHealthLevel - 1) * 0.1f) + 1f;
        PlayerLifes = Lvls.ExtraLifeLevel - 1;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameOverHUD.SetActive(false);
    }
    

    void FixedUpdate(){
        if(currentHealth <= 0){
            PlayerDeath();
        }else if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.SetMaxHealth(maxHealth);
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

    //What happend when the player die
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
