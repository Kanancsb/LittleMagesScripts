using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : MonoBehaviour
{
    public PlayerKnowledge Lvls;

    public Transform SpellPosition;

    public GameObject impacEffect;

    GameObject FindNearestTarget(GameObject[] targets, Vector3 position){
        float minDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        foreach (GameObject target in targets){
            float distance = Vector3.Distance(target.transform.position, position);

            if (distance < minDistance){
                minDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

    public void ShootSpell(GameObject projectile){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - SpellPosition.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject newProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    public void ExtraSpell(int extraSpell, GameObject projectile){
        if (extraSpell > 0){
            // Create ExtraSpell number of additional projectiles
            for (int i = 0; i < extraSpell; i++){
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
                List<GameObject> targets = new List<GameObject>();
                targets.AddRange(enemies);
                targets.AddRange(bosses);

                // If targets are found, create another projectile towards a random target
                if (targets.Count > 0){
                    int randomIndex = Random.Range(0, targets.Count);
                    GameObject randomTarget = targets[randomIndex];
                    Vector2 extraSpellDirection = (randomTarget.transform.position - SpellPosition.position).normalized;
                    float extraSpellAngle = Mathf.Atan2(extraSpellDirection.y, extraSpellDirection.x) * Mathf.Rad2Deg;

                    GameObject extraProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(extraSpellAngle, Vector3.forward));
                }
            }
        }
    }

    public void AKBuffs(float projectileSpeed, float CastCD, int extraSpell){
        projectileSpeed *= ((Lvls.SpellSpeedLevel - 1) * 0.05f) + 1f;
        float reductionFactor = Mathf.Pow(0.95f, Lvls.CDLevel - 1);
        CastCD *= reductionFactor;
        extraSpell = Lvls.ExtraSpellLevel - 1;
    }

}
