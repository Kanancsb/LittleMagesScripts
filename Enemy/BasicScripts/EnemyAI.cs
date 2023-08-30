using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float speed = 5f;
    public Transform enemyGFX;
    bool isFacingRight = true;

    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (Player != null){
            // Calcula a direção para o personagem
            Vector3 direction = Player.transform.position - transform.position;
            direction.Normalize();

            // Move o objeto na direção do personagem
            transform.position += direction * speed * Time.deltaTime;

            FlipEnemy(direction);
        }
    }

    void FlipEnemy(Vector3 direction)
    {
        if (direction.x > 0 && !isFacingRight)
        {
            // "Flip" para a direita
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (direction.x < 0 && isFacingRight)
        {
            // "Flip" para a esquerda
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
    }
}
