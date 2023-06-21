using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public Texture2D CursorTexture;
    private Vector2 CursorHotspot;

    public AudioSource ButtonSound;

    public float IncreaseObjectScale = 0.1f;

    void Start(){        
        CursorHotspot = new Vector2(CursorTexture.width  / 2, CursorTexture.height / 2);
        Cursor.SetCursor(CursorTexture, CursorHotspot, CursorMode.Auto);
    }

    public void ButtonTransparent(Button button, Color transparentColor){
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = transparentColor;
        colorBlock.highlightedColor = transparentColor;
    }

    public void OnMouseEnter(Transform ObjectScale){
        ButtonSound.Play();

        ObjectScale.localScale += new Vector3(IncreaseObjectScale, 0f, 0f);
    }

    public void OnMouseExit(Transform ObjectScale){       
        ObjectScale.localScale -= new Vector3(IncreaseObjectScale, 0f, 0f);
    }
}
