using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody;

    public int damage;

    public float Speed;

    void Start()
    {
        // Get the Rigidbody2D component attached to the enemy spell
        rigidbody = GetComponent<Rigidbody2D>();

        // Find the player object using the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Calculate the direction from the enemy spell to the player
        Vector3 direction = player.transform.position - transform.position;

        // Set the velocity of the enemy spell to move towards the player
        rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * Speed;

        // Calculate the rotation angle to face the player
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the enemy spell
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        StartCoroutine(ProjectileFade());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy spell collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Destroy the enemy spell
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileFade(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
