using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleWeaponPowerUp : MonoBehaviour
{
    public BasicSpell basicSpell;

    public GameObject RerollHUD;

    // Array of power-up game objects
    public GameObject[] PowerUps;

    // List to keep track of active power-ups
    private List<GameObject> activePowerUps = new List<GameObject>();

    // Activate random power-ups on Awake
    void Awake(){
        int count = Mathf.Min(PowerUps.Length, 3);
        ActivateRandomPowerUps(count);
    }

    // Deactivate and activate random power-ups on re-enabling the script
    void OnEnable(){
        DeactivatePowerUps();
        int count = Mathf.Min(PowerUps.Length, 3);
        ActivateRandomPowerUps(count);
    }

    void Update(){
        if(basicSpell.Roll> 0){
            RerollHUD.SetActive(true);
        }else{
            RerollHUD.SetActive(false);
        }
    }

    // Deactivate all active power-ups
    void DeactivatePowerUps(){
        foreach (GameObject powerUp in activePowerUps){
            if (powerUp != null){
                powerUp.SetActive(false);
            }
        }
        activePowerUps.Clear();
    }

    // Activate a specified number of random power-ups
    void ActivateRandomPowerUps(int count){
        int powerUpCount = Mathf.Min(count, PowerUps.Length);

        // Create a copy of the power-ups array
        List<GameObject> powerUpsCopy = new List<GameObject>(PowerUps);

        for (int i = 0; i < powerUpCount; i++){
            // Get a random index within the remaining power-ups
            int randomIndex = Random.Range(0, powerUpsCopy.Count);

            // Get the power-up at the random index
            GameObject powerUp = powerUpsCopy[randomIndex];

            // If the power-up is null, skip to the next iteration
            if (powerUp == null){
                if(powerUpCount < 20){
                    powerUpCount++;
                }
                continue;
            }else{
                // Activate the power-up
                powerUp.SetActive(true);

                // Add the power-up to the active power-ups list
                activePowerUps.Add(powerUp);

                // Remove the power-up from the copy to avoid duplicates
                powerUpsCopy.RemoveAt(randomIndex);
            }
        }
    }

    public void Reroll(){
            DeactivatePowerUps();
            ActivateRandomPowerUps(3);
            basicSpell.Roll--;
    }
}
