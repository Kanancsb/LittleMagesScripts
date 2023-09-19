using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;

    public FireArmor fireArmor;

    public GameObject ImpactSound;
    public AudioSource impactSound;

    void Start(){
        ImpactSound = GameObject.Find("Hit1");
        impactSound = ImpactSound.GetComponent<AudioSource>();
        fireArmor = FindObjectOfType<FireArmor>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null){
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
        }
    }
}
