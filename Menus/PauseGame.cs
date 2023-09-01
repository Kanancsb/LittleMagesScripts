using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public PlayerKnowledge SaveGame;

    public GameObject PauseGameHUD;
    public GameObject OptionsHUD;

    public AudioMixer GeneralVolume;
    public AudioMixer MusicVolume;
    
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private bool IsPaused = false;

    void Start(){

        PauseGameHUD.SetActive(false);
        OptionsHUD.SetActive(false);

        ResolutionLogic();
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape) && !IsPaused){
            PauseGameHUD.SetActive(true);
            Time.timeScale = 0;
            IsPaused = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && OptionsHUD.activeInHierarchy){
            Back();
        }else if(Input.GetKeyDown(KeyCode.Escape) && IsPaused && !OptionsHUD.activeInHierarchy){
            Resume();
        }
    }

    public void Resume(){
        PauseGameHUD.SetActive(false);
        OptionsHUD.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    public void OptionsMenu(){
        PauseGameHUD.SetActive(false);
        OptionsHUD.SetActive(true);
    }

    public void Back(){
        PauseGameHUD.SetActive(true);
        OptionsHUD.SetActive(false);
    }

    public void MainMenu(){
        Time.timeScale = 1;
        SaveGame.SavePlayer();
        SceneManager.LoadScene("MainMenu");
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
