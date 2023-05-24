using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float projectileSpeed;

    public int damage = 10;

    public Rigidbody2D rigidbody;

    void Start(){
        rigidbody.velocity = transform.right * projectileSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision){
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
