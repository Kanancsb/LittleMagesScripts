using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform playerTransform;
    public GameObject[] activeObjects;

    private Vector3 playerStartPosition;

    private SaveGameManager saveGameManager;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
            playerStartPosition = playerTransform.position;
        }

        saveGameManager = FindObjectOfType<SaveGameManager>();

        if (saveGameManager != null && saveGameManager.IsSave){
            LoadData();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerTransform.position.z);

        for (int i = 0; i < activeObjects.Length; i++)
        {
            PlayerPrefs.SetInt("Object" + i, activeObjects[i].activeSelf ? 1 : 0);
        }
        PlayerPrefs.Save();

        if (saveGameManager != null){
            saveGameManager.IsSave = true;
        }
    }

    public void LoadData()
    {
        playerStartPosition = playerTransform.position;

        Vector3 playerPos = new Vector3(
            PlayerPrefs.GetFloat("PlayerPosX", 0),
            PlayerPrefs.GetFloat("PlayerPosY", 0),
            PlayerPrefs.GetFloat("PlayerPosZ", 0)
        );

        playerTransform.position = playerPos;

        for (int i = 0; i < activeObjects.Length; i++)
        {
            activeObjects[i].SetActive(PlayerPrefs.GetInt("Object" + i, 0) == 1);
        }
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");

        for (int i = 0; i < activeObjects.Length; i++)
        {
            PlayerPrefs.DeleteKey("Object" + i);
        }
        PlayerPrefs.Save();

        if (saveGameManager != null)
        {
            saveGameManager.IsSave = false;
        }
    }
}
