using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bright : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBright;

    void Start(){
        slider.value = PlayerPrefs.GetFloat("bright", 0.5f);

        // Obtenha a cor atual do painel e defina o novo valor de alfa
        Color panelColor = panelBright.color;
        panelColor.a = slider.value;
        panelBright.color = panelColor;
    }

    public void ChangeSlider(float value){
        sliderValue = value;
        PlayerPrefs.SetFloat("bright", sliderValue);

        // Atualize o valor de alfa da cor do painel
        Color panelColor = panelBright.color;
        panelColor.a = slider.value;
        panelBright.color = panelColor;
    }
}
