using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiSpawn : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectilePosition;
    
    public float ProjectileCD = 5f;

    void Start(){
        ProjectilePosition = GameObject.FindGameObjectWithTag("SpellSpawn").transform;
        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile(){
        yield return new WaitForSeconds(ProjectileCD);
        Spell();
        StartCoroutine(ShootProjectile());
    }

    void Spell(){
        Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
    }
}
