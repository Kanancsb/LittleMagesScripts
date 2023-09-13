using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireWheel : MonoBehaviour
{
    public FireWheelSpell fireWheelSpell;
    public Rigidbody2D rigidbody;
    public PlayerHealth currentHealth;
    public float detectionRange = 5f;

    private Transform target;
    private List<Transform> hitEnemies = new List<Transform>();

    public GameObject ImpactSound;
    public AudioSource impactSound;

    private int hitsOnSameEnemy = 0;
    public bool imbuement = false;


    void Start(){

        ImpactSound = GameObject.Find("Hit1");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireWheelSpell = FindObjectOfType<FireWheelSpell>();
        rigidbody.velocity = transform.right * fireWheelSpell.projectileSpeed;
        currentHealth = FindObjectOfType<PlayerHealth>();
        StartCoroutine(ProjectileFade());
    }

    void FixedUpdate(){

        if (target != null && !hitEnemies.Contains(target)){
            Vector2 direction = target.position - transform.position;
            rigidbody.velocity = direction.normalized * fireWheelSpell.projectileSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.layer == LayerMask.NameToLayer("Bricks")){
            impactSound.Play();
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            fireWheelSpell.DamageCont += fireWheelSpell.damage;
            hitEnemies.Add(enemy.transform);

            if (fireWheelSpell.LifeSteal != 0){

                float lifeStealAmount = fireWheelSpell.damage * fireWheelSpell.LifeSteal;
                enemy.TakeDamage(fireWheelSpell.damage, fireWheelSpell.critDamage);
                currentHealth.currentHealth += lifeStealAmount;
            }else{
                enemy.TakeDamage(fireWheelSpell.damage, fireWheelSpell.critDamage);
            }

            if (target == null || hitEnemies.Contains(target)){

                target = FindClosestEnemy();
            }
            impactSound.Play();
        }
    }

    public Transform FindClosestEnemy(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Concat(GameObject.FindGameObjectsWithTag("Boss")).ToArray();
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies){

            if (!hitEnemies.Contains(enemy.transform)){

                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance <= detectionRange && distance < closestDistance){

                    closestEnemy = enemy.transform;
                    closestDistance = distance;
                }
            }
        }

        return closestEnemy;
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
