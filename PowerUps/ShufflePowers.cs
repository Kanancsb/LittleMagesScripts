using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePowers : MonoBehaviour
{
    public GameController gameController;

    public GameObject RerollHUD;

    // Array of power-up game objects
    public GameObject[] PowerUps;

    public FireWheelSpell FireWheelChosen;
    public GameObject[] FireWheelPowerUps;

    public FireMissile FireMissileChosen;
    public GameObject[] FireMissilePowerUps;

    public MegaFireball MegaFireballChosen;
    public GameObject[] MegaFireballPowerUps;

    public LivingBomb LivingBombChosen;
    public GameObject[] LivingBombPowerUps;

    public FireOrb FireOrbChosen;
    public GameObject[] FireOrbPowerUps;

    public FireGhost FireGhostChosen;
    public GameObject[] FireGhostPowerUps;


    // List to keep track of active power-ups
    private List<GameObject> activePowerUps = new List<GameObject>();

    // Activate random power-ups on Awake
    void Awake(){
        ActivateRandomPowerUps(3);
    }

    // Deactivate and activate random power-ups on re-enabling the script
    void OnEnable(){
        SpellsPowers();
        DeactivatePowerUps();
        ActivateRandomPowerUps(3);       
    }

    void Update(){
        if(gameController.Reroll > 0){
            RerollHUD.SetActive(true);
        }else{
            RerollHUD.SetActive(false);
        }
    }

    // Deactivate all active power-ups
    public void DeactivatePowerUps(){
        foreach (GameObject powerUp in activePowerUps){
            powerUp.SetActive(false);
        }
        activePowerUps.Clear();
    }

    // Activate a specified number of random power-ups
    public void ActivateRandomPowerUps(int count){
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

    T[] ExtendArray<T>(T[] array, T[] newElements){
        T[] newArray = new T[array.Length + newElements.Length];
        array.CopyTo(newArray, 0);
        newElements.CopyTo(newArray, array.Length);
        return newArray;
    }

    public void Reroll(){
            DeactivatePowerUps();
            ActivateRandomPowerUps(3);
            gameController.Reroll--;
    }

    public void SpellsPowers(){
        if(FireWheelChosen.FWChosen){
            PowerUps = ExtendArray(PowerUps, FireWheelPowerUps);
            FireWheelChosen.FWChosen = false;
        }else if(FireMissileChosen.FMChosen){
            PowerUps = ExtendArray(PowerUps, FireMissilePowerUps);
            FireMissileChosen.FMChosen = false;
        }else if(MegaFireballChosen.MFChosen){
            PowerUps = ExtendArray(PowerUps, MegaFireballPowerUps);
            MegaFireballChosen.MFChosen = false;
        }else if(LivingBombChosen.LVChosen){
            PowerUps = ExtendArray(PowerUps, LivingBombPowerUps);
            LivingBombChosen.LVChosen = false;
        }else if(FireOrbChosen.FOChosen){
            PowerUps = ExtendArray(PowerUps, FireOrbPowerUps);
            FireOrbChosen.FOChosen = false;
        }else if (FireGhostChosen.FGChosen){
            PowerUps = ExtendArray(PowerUps, FireGhostPowerUps);
            FireGhostChosen.FGChosen = false;
        }
    }
}
