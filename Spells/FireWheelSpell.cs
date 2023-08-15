using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWheelSpell : MonoBehaviour
{

    public PlayerKnowledge Lvls;
    public ShootLogic shootLogic;

    public Transform SpellPosition;
    public GameObject projectile;

    public float CastCD = 3.0f;
    float lastCast = 0;

    public Image SpellImage;
    bool CooldownImage = false;

    public float damage = 10f;
    public float projectileSpeed = 6f;
    public float LifeSteal;
    public int extraSpell;

    string Button;
    public WeaponPowerUp button;
    public bool FMChosen = false;
    public bool FWChosen = false;

    void Start(){

        shootLogic = FindObjectOfType<ShootLogic>();

        shootLogic.AKBuffs(projectileSpeed, CastCD, extraSpell);

        if(button.SpellButton == 1){
            Button = "Fire2";
        }else if(button.SpellButton == 2){
            Button = "Q";
        }else if(button.SpellButton == 3){
            Button = "E";
        }

        if(button.SpellButton > 0){
            FWChosen = true;
        }

        SpellImage.gameObject.SetActive(gameObject.activeSelf);
    }
    

    void Update(){
        // Check if the left mouse button is pressed and enough time has passed since the last cast
        if (Input.GetButtonDown(Button) && Time.time - lastCast >= CastCD){
            shootLogic.ShootSpell(projectile);
            shootLogic.ExtraSpell(extraSpell, projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
        }

        if (CooldownImage){
            SpellImage.fillAmount -= 1f / CastCD * Time.deltaTime;

            if (SpellImage.fillAmount <= 0){
                CooldownImage = false;
            }
        }
    }
}
