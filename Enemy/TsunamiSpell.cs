using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiSpell : MonoBehaviour
{

    public Transform target;
    public Rigidbody2D rigidbody;

    public int damage = 30;
    public float moveSpeed = 5f;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    public FireArmor fireArmor;

    void Start(){
        fireArmor = FindObjectOfType<FireArmor>();
        ImpactSound = GameObject.Find("Hit2");
        impactSound = ImpactSound.GetComponent<AudioSource>();

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
        impactSound.Play();
        if(collision.gameObject.CompareTag("Player")){
            if(fireArmor.FireArmorSpell){
                fireArmor.Backslash(damage, GetComponent<Enemy>(), impactSound);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }else{
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

}
