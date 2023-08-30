using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSpell : MonoBehaviour
{
    public PlayerKnowledge Lvls;
    public ShootLogic shootLogic;

    // Reference to the position where the spell will be cast from
    public Transform SpellPosition;

    // Reference to the projectile game object
    public GameObject projectile;

    public Image SpellImage;
    bool CooldownImage = false;

    // Cooldown between spell casts
    public float CastCD = 1f;
    float extraCD;
    float lastCast;
    float extraLastCast;

    public float damage = 10f;
    public float projectileSpeed = 6f;
    public float LifeSteal;
    public int SpellResist = 0;

    public int extraSpell;

    public float MaxHealth = 100;
    public int ExtraLife;
    public int Roll;

    void Start(){
        Lvls = FindObjectOfType<PlayerKnowledge>();
        shootLogic = FindObjectOfType<ShootLogic>();

        projectileSpeed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        CastCD *= reductionFactor;
        extraCD = CastCD * 2.5f;
        extraSpell = Lvls.ExtraSpellLevel;

        // Don't ask why, but this only works in this script
        MaxHealth *= ((Lvls.PlayerHealthLevel - 1) * 0.1f) + 1f;
        ExtraLife = Lvls.ExtraLifeLevel - 1;
        Roll = Lvls.RerollLevel - 1;
        // ---- !
    }

    void Update(){
        if (Input.GetMouseButtonDown(0) && Time.time - lastCast >= CastCD){
            shootLogic.ShootSpell(projectile);

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
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
