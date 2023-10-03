using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenuLogic : MonoBehaviour
{
    public PlayerKnowledge SaveGame;
    
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loading;
    public GameObject AKMenu;
    public GameObject controlsMenu;
    public GameObject BonusOption;
    public GameObject bonusModeMenu;
    public GameObject monsterBookMenu;

    public AudioMixer GeneralVolume;
    public AudioMixer MusicVolume;

    public TMP_Dropdown resolutionDropdown;

    public AudioSource StartSound;

    Resolution[] resolutions;

    public Toggle autoShootToggle;
    public Toggle aquiredAutoShootToggle;

    public Slider generalVolumeSlider;
    public Slider musicVolumeSlider;

    void Start(){
        PlayerVolume();

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        controlsMenu.SetActive(false);
        AKMenu.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        PlayerVolume();
        ResolutionLogic();

        autoShootToggle.isOn = SaveGame.AutoShoot;
        aquiredAutoShootToggle.isOn = SaveGame.AquiredAutoShoot;

        if(SaveGame.BonusMode){
            BonusOption.SetActive(true);
        }
    }

    public void StartButton(){
        loading.SetActive(true);
        mainMenu.SetActive(false);
        StartSound.Play();
        SceneManager.LoadScene("FightScene-EN-US");
    }

    public void StartBasicBonus(){
        loading.SetActive(true);
        mainMenu.SetActive(false);
        StartSound.Play();
    }

    public void StartInfiniteBonus(){
        loading.SetActive(true);
        mainMenu.SetActive(false);
        StartSound.Play();
        SceneManager.LoadScene("InfiniteMode-EN-US");
    }

    public void BonusModeMenu(){
        mainMenu.SetActive(false);
        bonusModeMenu.SetActive(true);
    }

    public void AncestralKnowledgeButton(){
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        AKMenu.SetActive(true);
    }

    public void MonsterBookButton(){
        mainMenu.SetActive(false);
        monsterBookMenu.SetActive(true);
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
        bonusModeMenu.SetActive(false);
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void AutoShoot(bool autoShoot){
        SaveGame.AutoShoot = autoShoot;
        SaveGame.SavePlayer();
    }

    public void AquiredAutoShoot(bool aquiredAutoShoot){
        SaveGame.AquiredAutoShoot = aquiredAutoShoot;
        SaveGame.SavePlayer();
    }

    public void SetGeneralVolume(float Volume){
        GeneralVolume.SetFloat("GeneralVolumeParameter", Mathf.Log10(Volume) * 20);
        PlayerPrefs.SetFloat("GeneralVolume", Volume);

        generalVolumeSlider.value = Volume;
    }

    public void SetMusicVolume(float Volume){
        MusicVolume.SetFloat("MusicVolumeParameter", Mathf.Log10(Volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", Volume);

        musicVolumeSlider.value = Volume;
    }

    public void PlayerVolume(){
        float savedGeneralVolume = PlayerPrefs.GetFloat("GeneralVolume", 1.0f);
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);

        GeneralVolume.SetFloat("GeneralVolumeParameter", Mathf.Log10(savedGeneralVolume) * 20);
        MusicVolume.SetFloat("MusicVolumeParameter", Mathf.Log10(savedMusicVolume) * 20);

        generalVolumeSlider.value = savedGeneralVolume;
        musicVolumeSlider.value = savedMusicVolume;
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
