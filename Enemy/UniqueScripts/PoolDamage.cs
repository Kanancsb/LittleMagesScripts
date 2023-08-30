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
        StartCoroutine(SelfDestroy());
    }

    void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            playerHealth.TakeDamage(damage * Time.deltaTime);
        }
    }

    IEnumerator SelfDestroy(){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
