using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMissile : MonoBehaviour
{
    // Reference to the position where the spell will be cast from
    public Transform SpellPosition;

    // Reference to the projectile game object
    public GameObject projectile;

    // Cooldown between spell casts
    public float CastCD = 3.0f;

    // Time of the last spell cast
    float lastCast;

    public Image SpellImage;
    bool CooldownImage = false;

    // Damage inflicted by the spell
    public float damage = 10f;

    // Speed of the projectile
    public float projectileSpeed = 6f;

    public float LifeSteal;

    string Button;
    public WeaponPowerUp button;
    public bool FMChosen = false;

    void Start(){

        lastCast = CastCD;

        if(button.SpellButton == 1){
            Button = "Fire2";
        }else if(button.SpellButton == 2){
            Button = "Q";
        }else if(button.SpellButton == 3){
            Button = "E";
        }

        if(button.SpellButton > 0){
            FMChosen = true;
        }

        SpellImage.gameObject.SetActive(gameObject.activeSelf);
    }

    void Update(){
        // Check if the left mouse button is pressed and enough time has passed since the last cast
        if (Input.GetButtonDown(Button) && Time.time - lastCast >= CastCD){
            // Calculate the direction from the spell position to the mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - SpellPosition.position).normalized;

            // Calculate the angle of the direction in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Create a new projectile at the spell position with the calculated angle
            GameObject newProjectile = Instantiate(projectile, SpellPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));

            // Set the time of the last cast to the current time
            lastCast = Time.time;
            CooldownImage = true;
            SpellImage.fillAmount = 1f;
        }

        if (CooldownImage){
            SpellImage.fillAmount -= 1f / CastCD * Time.deltaTime;

            if (SpellImage.fillAmount <= 0){
                CooldownImage = false;
            }
        }
    }
}