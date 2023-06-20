using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D CursorTexture;

    Vector2 CursorHotspot;

    public Button DefaultButton;
    public Color transparentColor;

    void Start(){
        
        CursorHotspot = new Vector2(CursorTexture.width  / 2, CursorTexture.height / 2);
        Cursor.SetCursor(CursorTexture, CursorHotspot, CursorMode.Auto);
    }

    public void ButtonTransparent(){
        ColorBlock colorBlock = DefaultButton.colors;
        colorBlock.normalColor = transparentColor;
        colorBlock.highlightedColor = transparentColor;
    }
}
