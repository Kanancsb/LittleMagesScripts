using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDamage : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;
    public float timer;

    void Start(){
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
            StartCoroutine(SelfDestroy());
        }
    }

    IEnumerator SelfDestroy(){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
