using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyWaveTracker : MonoBehaviour
{
   // put this on your enemy prefabs. You could just copy the on destroy onto a pre-existing script if you want.
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<WavePBS>().spawnedEnemies.Remove(gameObject);
        }
     
    }
}