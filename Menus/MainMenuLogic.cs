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
    public GameObject AKMenu;
    public GameObject controlsMenu;

    public AudioMixer GeneralVolume;
    public AudioMixer MusicVolume;

    public TMP_Dropdown resolutionDropdown;

    public AudioSource StartSound;

    Resolution[] resolutions;

    void Start(){

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        buttonsMenu.SetActive(false);
        AKMenu.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        ResolutionLogic();

    }

    public void StartButton(){
        loading.SetActive(true);
        mainMenu.SetActive(false);
        StartSound.Play();
        SceneManager.LoadScene("FightScene-EN-US");
    }

    public void AncestralKnowledgeButton(){
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        AKMenu.SetActive(true);
    }

    public void OptionsButton(){
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ControlsButton(){
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ReturnToMainMenuButton(){
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        AKMenu.SetActive(false);
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetGeneralVolume(float Volume){
        GeneralVolume.SetFloat("GeneralVolumeParameter",  Mathf.Log10(Volume) * 20);
    }

    public void SetMusicVolume(float Volume){
        MusicVolume.SetFloat("MusicVolumeParameter", Mathf.Log10(Volume) * 20);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void ResolutionLogic(){
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        int currentResolutionIndex = 0;

        for(int i=0; i < resolutions.Length; i++){
            // Calculate the aspect ratio as a floating-point value
            float aspectRatio = (float)resolutions[i].width / (float)resolutions[i].height;

            // Check if the aspect ratio is approximately 16:9
            if (Mathf.Approximately(aspectRatio, 16f / 9f)) {
                string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
                options.Add(new TMP_Dropdown.OptionData(option));

                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                    currentResolutionIndex = i;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


}
