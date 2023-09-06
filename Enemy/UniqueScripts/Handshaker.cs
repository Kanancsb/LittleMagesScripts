using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handshaker : MonoBehaviour
{
    public GameObject Hands;
    public float timer = 1;
    public float yPosition = -4.474f;
    
    private void Start(){
        InvokeRepeating("InstantiateObject", 0.0f, timer);
    }

    private void InstantiateObject(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null){
            Vector3 newPosition = new Vector3(player.transform.position.x, yPosition, player.transform.position.z);
            Instantiate(Hands, newPosition, Quaternion.identity);
        }
    }
}
