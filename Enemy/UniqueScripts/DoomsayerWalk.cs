using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomsayerWalk : MonoBehaviour
{
    public Transform enemyObject;
    public List<Transform> targetPoints;
    public float moveSpeed = 5f;

    private int currentIndex = 0;
    private bool movingForward = true;

    void Start()
    {
        if (targetPoints.Count > 0 && enemyObject != null)
        {
            enemyObject.position = targetPoints[0].position;
        }
    }

    void Update()
    {
        Movements(targetPoints, moveSpeed, ref currentIndex, ref movingForward);
    }

    public void Movements(List<Transform> targetPoints, float moveSpeed, ref int currentIndex, ref bool movingForward)
    {
        if (targetPoints.Count <= 0 || enemyObject == null) return;
        // Move towards the target
        enemyObject.position = Vector2.MoveTowards(enemyObject.position, targetPoints[currentIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector2.Distance(enemyObject.position, targetPoints[currentIndex].position) < 0.1f)
        {
            // Update the current index based on moving direction
            if (movingForward)
            {
                currentIndex++;
                if (currentIndex >= targetPoints.Count)
                {
                    currentIndex = targetPoints.Count - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = 1;
                    movingForward = true;
                }
            }
        }
    }

    /*public GameObject[] Positions;
    public float timer;

    void Start(){
        StartCoroutine(MoveStyle(Positions, timer));
    }

    IEnumerator MoveStyle(GameObject[] Positions, float Timer){
        yield return new WaitForSeconds(timer);
        Positions[0].SetActive(true);
        yield return new WaitForSeconds(timer);
        Positions[0].SetActive(false);
        Positions[1].SetActive(true);
        yield return new WaitForSeconds(timer);
        Positions[1].SetActive(false);
        StartCoroutine(MoveStyle(Positions, timer));
    }*/
}
