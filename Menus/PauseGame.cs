using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseGame : MonoBehaviour
{

    public GameObject PauseGameHUD;
    public GameObject OptionsHUD;

    public AudioMixer GeneralVolume;
    public AudioMixer MusicVolume;
    
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start(){

        PauseGameHUD.SetActive(false);
        OptionsHUD.SetActive(false);

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

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseGameHUD.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume(){
        PauseGameHUD.SetActive(false);
        OptionsHUD.SetActive(false);
        Time.timeScale = 1;
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
        SceneManager.LoadScene("MainMenu");
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetGeneralVolume(float Volume){
        GeneralVolume.SetFloat("volume", Volume);
    }

    public void SetMusicVolume(float Volume){
        MusicVolume.SetFloat("volume", Volume);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QuitButton(){
        Application.Quit();
    }
}
