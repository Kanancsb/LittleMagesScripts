using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicSpell : MonoBehaviour
{

    public PlayerKnowledge Lvls;

    // Reference to the position where the spell will be cast from
    public Transform SpellPosition;

    // Reference to the projectile game object
    public GameObject projectile;

    public Image SpellImage;
    bool CooldownImage = false;

    // Cooldown between spell casts
    public float CastCD = 1f;
    float lastCast;

    public float damage = 10f;
    public float projectileSpeed = 6f;
    public float LifeSteal;

    public int ExtraSpell;

    public float MaxHealth = 100;
    public int ExtraLife;
    public int Roll;

    void Start(){
        damage *= ((Lvls.DamageLevel - 1) * 0.05f) + 1f;

        projectileSpeed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        CastCD *= reductionFactor;

        ExtraSpell = Lvls.ExtraSpellLevel - 1;

        // Don't ask why, but this only works in this script
        MaxHealth *= ((Lvls.PlayerHealthLevel - 1) * 0.1f) + 1f;
        ExtraLife = Lvls.ExtraLifeLevel - 1;
        Roll = Lvls.RerollLevel - 1;

        // ---- !
    }

    void Update(){
        // Check if the left mouse button is pressed and enough time has passed since the last cast
        if (Input.GetMouseButtonDown(0) && Time.time - lastCast >= CastCD){

            // Calculate the direction from the spell position to the mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - SpellPosition.position).normalized;

            // Calculate the angle of the direction in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Create a new projectile at the spell position with the calculated angle
            GameObject newProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));

            if (ExtraSpell > 0){
            // Create ExtraSpell number of additional projectiles
            for (int i = 0; i < ExtraSpell; i++)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
                List<GameObject> targets = new List<GameObject>();
                targets.AddRange(enemies);
                targets.AddRange(bosses);

                // If targets are found, create another projectile towards a random target
                if (targets.Count > 0)
                {
                    int randomIndex = Random.Range(0, targets.Count);
                    GameObject randomTarget = targets[randomIndex];
                    Vector2 extraSpellDirection = (randomTarget.transform.position - SpellPosition.position).normalized;
                    float extraSpellAngle = Mathf.Atan2(extraSpellDirection.y, extraSpellDirection.x) * Mathf.Rad2Deg;

                    GameObject extraProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(extraSpellAngle, Vector3.forward));
                }
            }
        }

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

    GameObject FindNearestTarget(GameObject[] targets, Vector3 position)
    {
        float minDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(target.transform.position, position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }
}
