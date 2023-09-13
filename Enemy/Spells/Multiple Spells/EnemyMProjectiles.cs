using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMProjectiles : MonoBehaviour
{
    public GameObject[] ProjectilePrefab;
    public Transform ProjectilePosition;

    public float ProjectileCD = 5f;
    public float SpreadAngle = 10f;
    public float ProjectileSpeed = 10f;

    private bool firstProjectile = true;

    void OnEnable(){
        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles(){
        yield return new WaitForSeconds(ProjectileCD);
        ShootProjectilesInDirection(Vector3.down, ProjectileSpeed);
        StartCoroutine(ShootProjectiles());
    }

    void ShootProjectilesInDirection(Vector3 direction, float speed){
        InstantiateProjectile(direction.normalized, ProjectilePrefab[0], speed);

        if (!firstProjectile){
            Vector3 rightSpread = Quaternion.Euler(0, 0, SpreadAngle) * direction.normalized;
            InstantiateProjectile(rightSpread.normalized, ProjectilePrefab[1], speed);

            Vector3 leftSpread = Quaternion.Euler(0, 0, -SpreadAngle) * direction.normalized;
            InstantiateProjectile(leftSpread.normalized, ProjectilePrefab[2], speed);
        }
        firstProjectile = false;
    }

    void InstantiateProjectile(Vector3 direction, GameObject ProjectilePrefab, float speed){
        GameObject projectile = Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();

        projectileRigidbody.velocity = direction * speed;
    }

    private void OnDisable(){
        StopAllCoroutines();
    }
}
