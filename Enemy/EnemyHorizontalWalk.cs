using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalWalk : MonoBehaviour
{
    public List<Transform> targetPoints;
    public float moveSpeed = 5f;

    private int currentIndex = 0;
    private bool movingForward = true;

    void Start(){
        if (targetPoints.Count > 0){
            transform.position = targetPoints[0].position;
        }
    }

    void Update(){
        Moviments(targetPoints, moveSpeed, currentIndex, movingForward);
    }

    public void Moviments(List<Transform> targetPoints, float moveSpeed, int currentIndex, bool movingForward){
        if (targetPoints.Count <= 0) return;
        // Move towards the target
        transform.position = Vector2.MoveTowards(transform.position, targetPoints[currentIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector2.Distance(transform.position, targetPoints[currentIndex].position) < 0.1f){
            // Update the current index based on moving direction
            if (movingForward){
                currentIndex++;
                if (currentIndex >= targetPoints.Count){
                    currentIndex = targetPoints.Count - 2;
                    movingForward = false;
                }
            }else{
                currentIndex--;
                if (currentIndex < 0){
                    currentIndex = 1;
                    movingForward = true;
                }
            }
        }
    }
}
