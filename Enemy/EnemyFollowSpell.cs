using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowSpell : MonoBehaviour
{
    public EnemyProjectile enemyProjectile;
    public Rigidbody2D rigidbody;
    public Transform target;

    public int damage = 10;
    public float moveSpeed = 5f;

    public GameObject ImpactSound;
    public AudioSource impactSound;
    
    public FireArmor fireArmor;

    void Start(){
        ImpactSound = GameObject.Find("Hit1");
        impactSound = ImpactSound.GetComponent<AudioSource>();

        fireArmor = FindObjectOfType<FireArmor>();
        enemyProjectile = FindObjectOfType<EnemyProjectile>();
        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate(){
        if (target != null){
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 newPosition = rigidbody.position + direction * moveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(newPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        impactSound.Play();
        if(collision.gameObject.CompareTag("Player")){
            if(fireArmor.FireArmorSpell){
                fireArmor.Backslash(damage, GetComponent<Enemy>(), impactSound);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }else{
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }else if(collision.gameObject.CompareTag("PlayerSpell")){
            Destroy(gameObject);
        }
    }

}
