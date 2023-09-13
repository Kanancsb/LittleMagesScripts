using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaFireball : MonoBehaviour
{

    public PlayerKnowledge Lvls;
    public ShootLogic shootLogic;

    public Transform SpellPosition;
    public GameObject projectile;

    public float DamageCont;

    public float CastCD = 3.0f;
    float extraCD;
    float lastCast;
    float extraLastCast;

    public Image SpellImage;
    bool CooldownImage = false;

    public float damage = 10f;
    public float critDamage = 1f;
    public float projectileSpeed = 6f;
    public float LifeSteal;
    public int extraSpell;

    string Button;
    public WeaponPowerUp button;
    public bool MFChosen = false;
    public bool IChosen = false;

    public bool imbuement = false;

    void Start(){

        Lvls = FindObjectOfType<PlayerKnowledge>();
        shootLogic = FindObjectOfType<ShootLogic>();

        projectileSpeed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        CastCD *= reductionFactor;
        extraCD = CastCD * 2.5f;
        extraSpell = Lvls.ExtraSpellLevel;

        if(button.SpellButton == 1){
            Button = "Q";
        }else if(button.SpellButton == 2){
            Button = "W";
        }else if(button.SpellButton == 3){
            Button = "E";
        }else if(button.SpellButton == 4){
            Button = "R";
        }

        if(button.SpellButton > 0){
            MFChosen = true;
        }

        SpellImage.gameObject.SetActive(gameObject.activeSelf);
    }

    void Update(){
        // Check if the left mouse button is pressed and enough time has passed since the last cast
        if(!Lvls.AquiredAutoShoot){
            if (Input.GetButtonDown(Button) && Time.time - lastCast >= CastCD){
            shootLogic.ShootSpell(projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
            }
        }else{
            if(Time.time - lastCast >= CastCD){
            shootLogic.ShootSpell(projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
            }
        }

        if(Time.time - extraLastCast >= extraCD){
            shootLogic.ExtraSpell(extraSpell, projectile);
            extraLastCast = Time.time;
        }

        if (CooldownImage){
            SpellImage.fillAmount -= 1f / CastCD * Time.deltaTime;

            if (SpellImage.fillAmount <= 0){
                CooldownImage = false;
            }
        }
    }
}
