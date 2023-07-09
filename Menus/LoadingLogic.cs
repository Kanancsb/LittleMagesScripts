using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingLogic : MonoBehaviour
{
    public List<string> Tips = new List<string>();
    public TextMeshProUGUI TipMessage;

    void Start(){

        int randomIndex = Random.Range(0, Tips.Count);
        string randomTip = Tips[randomIndex];
        TipMessage.text = randomTip;
    }

}
