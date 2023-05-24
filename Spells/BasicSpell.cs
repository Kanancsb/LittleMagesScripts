using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : MonoBehaviour
{
    public Transform SpellPosition;

    public GameObject projectile;

    void Update(){
        if(Input.GetMouseButtonDown(0)){

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - SpellPosition.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject newProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));
        }
    }
}
