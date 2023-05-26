using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loading;
    public GameObject buttonsMenu;

    void Start(){

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        buttonsMenu.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void StartButton(){
        loading.SetActive(true);
        mainMenu.SetActive(false);
        SceneManager.LoadScene("FightScene-EN-US");
    }

    public void OptionsButton(){
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ReturnToMainMenuButton(){
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

}
