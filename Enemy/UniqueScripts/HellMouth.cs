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

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
