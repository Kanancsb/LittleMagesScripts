using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public float FadeTimer = 5;
    public float slowValue = 0.5f;
    public float originalSpeed;
    public PlayerMovement movement;

    void Start(){
        movement = FindObjectOfType<PlayerMovement>(); 
        StartCoroutine(ProjectileFade(FadeTimer));
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            originalSpeed = movement.runSpeed;
            movement.runSpeed *= slowValue;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            movement.runSpeed = originalSpeed;
        }
    }
    IEnumerator ProjectileFade(float timer){
        yield return new WaitForSeconds(timer);
        movement.runSpeed = originalSpeed;
        Destroy(gameObject);
    }
}
