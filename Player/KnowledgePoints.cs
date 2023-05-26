using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnowledgePoints : MonoBehaviour
{
    
    public PlayerKnowledge knowledge;

    int knowledgePoints;

    public TMP_Text knowledgePointsText;

    void Start(){
        knowledge = FindObjectOfType<PlayerKnowledge>();
    }

    void Update(){
        knowledgePoints = knowledge.Knowledge;
        knowledgePointsText.text = "Knowledge Points: " + knowledgePoints;
    }

}
