using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterSummary
{
    public GameObject MonsterType;
    public GameObject[] pages;
}

public class BookLogic : MonoBehaviour
{
    public List<MonsterSummary> MonstersPageList;
    public GameObject Summary;
    public int currentMonsterIndex = 0;
    public int currentPageIndex = 0;

    public void MonsterSection(int n){
        Summary.SetActive(false);
        currentMonsterIndex = n;
        MonstersPageList[n].MonsterType.SetActive(true);
        MonstersPageList[currentMonsterIndex].pages[currentPageIndex].SetActive(true);
    }

    public void NextPage(){
        
        MonstersPageList[currentMonsterIndex].pages[currentPageIndex].SetActive(false);

        if(currentMonsterIndex >= 3 && currentPageIndex >= 2){
            Summary.SetActive(true);
            MonstersPageList[currentMonsterIndex].MonsterType.SetActive(false);
            return;
        }else{
            currentPageIndex++;
        }
        
        if (currentPageIndex >= MonstersPageList[currentMonsterIndex].pages.Length){
            currentPageIndex = 0;

            foreach (var page in MonstersPageList[currentMonsterIndex].pages){
                page.SetActive(false);
            }
            MonstersPageList[currentMonsterIndex].MonsterType.SetActive(false);
            currentMonsterIndex++;
            MonstersPageList[currentMonsterIndex].MonsterType.SetActive(true);

            if (currentMonsterIndex >= MonstersPageList.Count){
                currentMonsterIndex = 0;
            }
        }

        MonstersPageList[currentMonsterIndex].pages[currentPageIndex].SetActive(true);
    }

    public void PreviousPage(){
        MonstersPageList[currentMonsterIndex].pages[currentPageIndex].SetActive(false);

        if (currentPageIndex <= 0){
            Summary.SetActive(true);
            MonstersPageList[currentMonsterIndex].MonsterType.SetActive(false);
            return;
            }
        
        currentPageIndex--;

        MonstersPageList[currentMonsterIndex].pages[currentPageIndex].SetActive(true);
    }
}
