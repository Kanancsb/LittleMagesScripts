using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    
    public GameObject WeaponPowerUpHUD;

    public void FireWheelSpell(){

        WeaponPowerUpHUD.SetActive(false);
    }
}
