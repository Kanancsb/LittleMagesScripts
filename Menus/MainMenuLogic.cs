using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenuLogic : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loading;
    public GameObject buttonsMenu;

    public AudioMixer GeneralVolume;
    public AudioMixer MusicVolume;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start(){

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        buttonsMenu.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Start the Resolution part

        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        int currentResolutionIndex = 0;

        for(int i=0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(new TMP_Dropdown.OptionData(option));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // End the Resolution part

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

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetGeneralVolume(float Volume){
        GeneralVolume.SetFloat("GeneralVolumeParameter", Volume);
    }

    public void SetMusicVolume(float Volume){
        MusicVolume.SetFloat("MusicVolumeParameter", Volume);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QuitButton(){
        Application.Quit();
    }

}
