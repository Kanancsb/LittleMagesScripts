using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolExplosion : MonoBehaviour
{
    public GameObject BloodPool;

    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            BloodPool.SetActive(true);
            BloodPool.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
