using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public float FadeTimer = 5;
    public float slowValue = 0.5f;
    public float originalSpeed;
    void Start(){
        StartCoroutine(ProjectileFade(FadeTimer));
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            originalSpeed = collision.gameObject.GetComponent<PlayerMovement>().runSpeed;
            collision.gameObject.GetComponent<PlayerMovement>().runSpeed *= slowValue;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerMovement>().runSpeed = originalSpeed;
        }
    }
    IEnumerator ProjectileFade(float timer){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
