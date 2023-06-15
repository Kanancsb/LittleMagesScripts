using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleWeaponPowerUp : MonoBehaviour
{
    // Array of power-up game objects
    public GameObject[] PowerUps;

    // List to keep track of active power-ups
    private List<GameObject> activePowerUps = new List<GameObject>();

    // Activate random power-ups on Awake
    void Awake(){
        ActivateRandomPowerUps(3);
    }

    // Deactivate and activate random power-ups on re-enabling the script
    void OnEnable(){
        DeactivatePowerUps();
        ActivateRandomPowerUps(3);
    }

    // Deactivate all active power-ups
    void DeactivatePowerUps(){
        foreach (GameObject powerUp in activePowerUps){
            powerUp.SetActive(false);
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

            // Activate the power-up
            powerUp.SetActive(true);

            // Add the power-up to the active power-ups list
            activePowerUps.Add(powerUp);

            // Remove the power-up from the copy to avoid duplicates
            powerUpsCopy.RemoveAt(randomIndex);
        }
    }
}