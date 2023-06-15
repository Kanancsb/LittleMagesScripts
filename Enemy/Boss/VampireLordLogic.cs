using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireLordLogic : MonoBehaviour
{

    public GameObject Light;

    int cont = 0;
    bool SpellStop = false;

    public GameObject ProjectilePrefab;
    public Transform ProjectilePosition;
    
    public float ProjectileCD = 5f;
    public float ActionCD = 5;

    private Enemy enemyHealth;
    float Health;
    public float Y = 10f;
    public float X = 10f;

    void Start(){
        enemyHealth = FindObjectOfType<Enemy>();
        Health = enemyHealth.health;
        Light.SetActive(false);
        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile(){
        if(!SpellStop){
            yield return new WaitForSeconds(ProjectileCD);
            cont++;
            Instantiate(ProjectilePrefab, ProjectilePosition.position, Quaternion.identity);
            if(cont >= 5){
                SpellStop = true;
            }
            StartCoroutine(ShootProjectile());
        }else{
            yield return new WaitForSeconds(ActionCD);
            cont = 0;
            SpellStop = false;
            StartCoroutine(ShootProjectile());
        }
    }

    void Update(){
        if(Health > enemyHealth.health){
            float teleportX = Random.Range(-X, X);
            float teleportY = Random.Range(1f, Y);
            Vector3 newPosition = new Vector3(teleportX, teleportY, transform.position.z);
            transform.position = newPosition;

            Health = enemyHealth.health;
        }
    }

}
