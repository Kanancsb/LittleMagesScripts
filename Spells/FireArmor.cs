using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArmor : MonoBehaviour
{
    public bool FireArmorSpell = false;
    public float cont = 0;
    public int maxEnemies = 10;

    public void Backslash(float damage){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = 0;
        foreach (GameObject enemyObject in enemies){
            if (enemyCount >= maxEnemies) break;
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            if (enemy != null){
                enemy.TakeDamage(damage * 0.2f, 2f);
                cont += damage;
                enemyCount++;
            }
        }
    }
}

