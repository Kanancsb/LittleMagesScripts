using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSideSpell : MonoBehaviour
{

    public Transform[] SpellPosition;
    public GameObject[] SpellsAttack;
    public float ProjectileCD = 5f;
    public float ProjectileSpeed = 5f;

    void OnEnable(){
        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile(){
        yield return new WaitForSeconds(ProjectileCD);
        Spell();
        StartCoroutine(ShootProjectile());
    }

    void Spell(){
        GameObject spellLeft = Instantiate(SpellsAttack[0], SpellPosition[0].position, Quaternion.identity);
        Rigidbody2D projectileRigidbody1 = spellLeft.GetComponent<Rigidbody2D>();
        projectileRigidbody1.velocity = -transform.right * ProjectileSpeed;

        GameObject spellRight = Instantiate(SpellsAttack[1], SpellPosition[1].position, Quaternion.identity);
        Rigidbody2D projectileRigidbody2 = spellRight.GetComponent<Rigidbody2D>();
        projectileRigidbody2.velocity = transform.right * ProjectileSpeed;
    }

    private void OnDisable(){
        StopAllCoroutines();
    }
}
