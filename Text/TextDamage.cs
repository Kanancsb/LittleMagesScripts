using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamage : MonoBehaviour
{
    public float DestroyTime;
    public Vector3 Offset = new Vector3(0, 0.5f, 0);
    public Vector3 RandomizeItensity = new Vector3(0.5f, 0f, 0f);

    void Start(){
        Destroy(gameObject, DestroyTime);

        transform.position += Offset;
        transform.position += new Vector3(Random.Range(-RandomizeItensity.x, RandomizeItensity.x), 0, 0);
    }
}
