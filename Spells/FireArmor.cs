using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArmor : MonoBehaviour
{
    public bool FireArmorSpell = false;

    public void Backslash(float damage, Enemy enemy, AudioSource sfx){
        enemy.TakeDamage(damage*0.5f);
        sfx.Play();
    }
}
