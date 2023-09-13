using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLaser : MonoBehaviour
{

    public int damage; 
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if(collision.gameObject.CompareTag("PlayerSpell")){
            Destroy(collision.gameObject);
        }
    }
}
