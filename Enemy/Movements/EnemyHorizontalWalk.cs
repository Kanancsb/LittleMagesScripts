using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalWalk : MonoBehaviour
{
    public List<Transform> targetPoints;
    public float moveSpeed = 5f;

    private int currentIndex = 0;
    private int direction = 1;

    void Start()
    {
        if (targetPoints.Count > 0)
        {
            transform.position = targetPoints[currentIndex].position;
        }
    }

    void Update()
    {
        Moviments(targetPoints, moveSpeed, ref currentIndex, ref direction);
    }

    public void Moviments(List<Transform> targetPoints, float moveSpeed, ref int currentIndex, ref int direction)
    {
        if (targetPoints.Count <= 0) return;

        // Move towards the target
        transform.position = Vector2.MoveTowards(transform.position, targetPoints[currentIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector2.Distance(transform.position, targetPoints[currentIndex].position) < 0.1f)
        {
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
