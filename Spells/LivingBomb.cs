using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBomb : MonoBehaviour
{
    
    public float timer;
    
    IEnumerator CountDown(){
        yield return new WaitForSeconds(timer);
        
    }
}
