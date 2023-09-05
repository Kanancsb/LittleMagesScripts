using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMProjectiles : MonoBehaviour
{
    public GameObject[] ProjectilePrefab;
    public Transform ProjectilePosition;

    public float ProjectileCD = 5f;
    public float SpreadAngle = 10f;
    public float ProjectileSpeed = 10f; // Adicione a velocidade do projétil aqui

    private bool firstProjectile = true;

    void Start()
    {
        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles()
    {
        yield return new WaitForSeconds(ProjectileCD);
        ShootProjectilesInDirection(Vector3.down, ProjectileSpeed); // Primeiro projetil vai para baixo
        StartCoroutine(ShootProjectiles());
    }

    void ShootProjectilesInDirection(Vector3 direction, float speed) // Receba a velocidade como parâmetro
    {
        // Instantiate the projectile
        InstantiateProjectile(direction.normalized, ProjectilePrefab[0], speed);

        if (!firstProjectile)
        {
            // Shoot slightly to the right
            Vector3 rightSpread = Quaternion.Euler(0, 0, SpreadAngle) * direction.normalized;
            InstantiateProjectile(rightSpread.normalized, ProjectilePrefab[1], speed);

            // Shoot slightly to the left
            Vector3 leftSpread = Quaternion.Euler(0, 0, -SpreadAngle) * direction.normalized;
            InstantiateProjectile(leftSpread.normalized, ProjectilePrefab[2], speed);
        }

        // Depois do primeiro projetil, set firstProjectile para false
        firstProjectile = false;
    }

    void InstantiateProjectile(Vector3 direction, GameObject ProjectilePrefab, float speed) // Receba a velocidade como parâmetro
    {
        GameObject projectile = Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile using the calculated direction and speed
        projectileRigidbody.velocity = direction * speed;
    }
}
