using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiSpell : MonoBehaviour
{

    public Transform target;
    public Rigidbody2D rigidbody;

    public int damage = 30;
    public float moveSpeed = 5f;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    void FixedUpdate(){
        if (target != null){
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 newPosition = rigidbody.position + direction * moveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(newPosition);

            float distanceToEnd = Vector2.Distance(transform.position, target.position);
            if (distanceToEnd <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
    

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
