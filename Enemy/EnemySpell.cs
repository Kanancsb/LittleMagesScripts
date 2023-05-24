using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody;

    public float Speed;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * Speed;
    }

}
