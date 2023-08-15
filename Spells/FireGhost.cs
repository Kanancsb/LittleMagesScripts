using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGhost : MonoBehaviour
{
    public PlayerKnowledge Lvls;
    public ShootLogic shootLogic;

    public Transform SpellPosition;
    public GameObject projectile;

    public Image SpellImage;
    bool CooldownImage = false;

    public float CastCD = 1f;
    private float lastCast = 5;

    public float damage = 50f;
    public float projectileSpeed = 5f;
    public float LifeSteal;
    public int extraSpell;

    private string Button;
    public WeaponPowerUp button;
    public bool FGChosen = false;

    void Start(){
        shootLogic = FindObjectOfType<ShootLogic>();

        shootLogic.AKBuffs(projectileSpeed, CastCD, extraSpell++);

        lastCast = CastCD;

        if(button.SpellButton == 1){
            Button = "Fire2";
        }else if(button.SpellButton == 2){
            Button = "Q";
        }else if(button.SpellButton == 3){
            Button = "E";
        }

        if(button.SpellButton > 0){
            FGChosen = true;
        }

        SpellImage.gameObject.SetActive(gameObject.activeSelf);
    }

    void Update(){
        if(Input.GetMouseButtonDown(1) && Time.time - lastCast >= CastCD){
            shootLogic.ExtraSpell(extraSpell, projectile);
            
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
