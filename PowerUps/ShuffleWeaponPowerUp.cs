using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleWeaponPowerUp : MonoBehaviour
{
    public GameController gameController;

    public GameObject PowerUpHUD;
    public GameObject RerollHUD;

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
    void DeactivatePowerUps(){
        foreach (GameObject powerUp in activePowerUps){
            if (powerUp != null){
                powerUp.SetActive(false);
            }
        }
        activePowerUps.Clear();
    }

    void ActivateRandomPowerUps(int count){
        int powerUpCount = Mathf.Min(count, PowerUps.Length);

        // Create a copy of the power-ups array
        List<GameObject> powerUpsCopy = new List<GameObject>(PowerUps);

        if(powerUpsCopy.Count > 0){
            for (int i = 0; i < powerUpCount; i++){
                int randomIndex = Random.Range(0, powerUpsCopy.Count);
                
                GameObject powerUp = powerUpsCopy[randomIndex];

                if (powerUp == null){
                    if(powerUpCount < 20){
                        powerUpCount++;
                    }
                    continue;
                }else{
                    powerUp.SetActive(true);
                    activePowerUps.Add(powerUp);

                    // Remove the power-up from the copy to avoid duplicates
                    powerUpsCopy.RemoveAt(randomIndex);
                }
            }
        }else{
            PowerUpHUD.SetActive(false);
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
        if(FireWheelChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, FireWheelPowerUps);
            FireWheelChosen.IChosen = false;
        }
        if(FireMissileChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, FireMissilePowerUps);
            FireMissileChosen.IChosen = false;
        }
        if(MegaFireballChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, MegaFireballPowerUps);
            MegaFireballChosen.IChosen = false;
        }
        if(LivingBombChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, LivingBombPowerUps);
            LivingBombChosen.IChosen = false;
        }
        if(FireOrbChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, FireOrbPowerUps);
            FireOrbChosen.IChosen = false;
        }
        if(FireGhostChosen.IChosen){
            PowerUps = ExtendArray(PowerUps, FireGhostPowerUps);
            FireGhostChosen.IChosen = false;
        }
    }
}
