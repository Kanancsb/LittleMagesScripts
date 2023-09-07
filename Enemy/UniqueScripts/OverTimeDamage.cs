using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // Certifique-se de incluir esse namespace

public class OverTimeDamage : MonoBehaviour
{
    public GameObject light;

    public PlayerHealth playerHealth;
    public UnityEngine.Rendering.Universal.Light2D worldLight;
    public GameController gameController;

    public float flickTime;
    public float Cd;
    public float damage;
    public float intensityChange = 0.2f;
    public Color targetColor;

    public float originalIntensity;
    public Color originalColor;

    void Start(){
        gameController = FindObjectOfType<GameController>();
        GameObject lightObject = GameObject.FindGameObjectWithTag("WorldLight");
        if (lightObject != null){
            worldLight = lightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        } 
        playerHealth = FindObjectOfType<PlayerHealth>();
        originalIntensity = gameController.worldLight;
        originalColor = gameController.worldColor;

        StartCoroutine(TimeDamage(Cd, damage, flickTime));
    }

    IEnumerator TimeDamage(float Cd, float damage, float flickTime){
        yield return new WaitForSeconds(Cd);
        playerHealth.TakeDamage(damage);

        worldLight.intensity -= intensityChange;
        worldLight.color = targetColor;

        yield return new WaitForSeconds(flickTime); // Aguarde 1 segundo

        worldLight.intensity = originalIntensity;
        worldLight.color = originalColor;

        StartCoroutine(TimeDamage(Cd, damage, flickTime));
    }
}
