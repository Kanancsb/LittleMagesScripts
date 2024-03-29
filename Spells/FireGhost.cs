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

    public float DamageCont;

    public Image SpellImage;
    bool CooldownImage = false;

    public float CastCD = 1f;
    private float lastCast = 5;

    public float damage = 50f;
    public float critDamage = 1f;
    public float projectileSpeed = 5f;
    public float LifeSteal;
    public int extraSpell;

    private string Button = "Q";
    public WeaponPowerUp button;
    public bool FGChosen = false;
    public bool IChosen = false;

    void Start(){
        Lvls = FindObjectOfType<PlayerKnowledge>();
        shootLogic = FindObjectOfType<ShootLogic>();

        projectileSpeed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        CastCD *= reductionFactor;
        extraSpell = Lvls.ExtraSpellLevel + 2;

        lastCast = CastCD;

        /*if(button.SpellButton == 1){
            Button = "Q";
        }else if(button.SpellButton == 2){
            Button = "W";
        }else if(button.SpellButton == 3){
            Button = "E";
        }else if(button.SpellButton == 4){
            Button = "R";
        }*/

        if(button.SpellButton > 0){
            FGChosen = true;
        }

        SpellImage.gameObject.SetActive(gameObject.activeSelf);
    }

    void Update(){
        if(!Lvls.AquiredAutoShoot){
            if (Input.GetButtonDown(Button) && Time.time - lastCast >= CastCD){
            shootLogic.ExtraSpell(extraSpell, projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
            }
        }else{
            if(Time.time - lastCast >= CastCD){
            shootLogic.ExtraSpell(extraSpell, projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
            }
        }

        if (CooldownImage){
            SpellImage.fillAmount -= 1f / CastCD * Time.deltaTime;

            if (SpellImage.fillAmount <= 0){
                CooldownImage = false;
            }
        }
    }
}
