using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellMouth : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    
    private void Start(){
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null){
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
    }

    private void Update(){
        // Get the direction from the object to the player
        if (playerHealth != null && playerHealth.transform != null) {
            Vector3 direction = playerHealth.transform.position - transform.position;
            direction.z = 0; // Make sure the direction is in the 2D plane
            direction.Normalize(); // Normalize the direction vector

            // Calculate the rotation angle based on the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation to the object
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
