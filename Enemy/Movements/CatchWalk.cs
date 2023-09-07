using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchWalk : MonoBehaviour
{
    public Transform pointsParent; // Referência ao objeto pai com os pontos de destino
    public float moveSpeed = 5f;

    private List<Transform> targetPoints = new List<Transform>(); // Lista de pontos de destino
    private int currentIndex = 0;
    private int direction = 1;

    void Start(){
        if (pointsParent != null){
            foreach (Transform child in pointsParent){
                targetPoints.Add(child);
            }
        }

        if (targetPoints.Count > 0){
            transform.position = targetPoints[currentIndex].position;
        }
    }

    void Update(){
        Moviments(moveSpeed, ref currentIndex, ref direction);
    }

    public void Moviments(float moveSpeed, ref int currentIndex, ref int direction){
        if (targetPoints.Count <= 0) return;

        // Move towards the target
        transform.position = Vector2.MoveTowards(transform.position, targetPoints[currentIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector2.Distance(transform.position, targetPoints[currentIndex].position) < 0.1f){
            // Update the current index based on direction
            currentIndex += direction;

            // Check for boundary conditions
            if (currentIndex >= targetPoints.Count || currentIndex < 0)
            {
                direction *= -1;

                // Adjust currentIndex to stay within bounds
                currentIndex = Mathf.Clamp(currentIndex, 0, targetPoints.Count - 1);
            }
        }
    }
}
