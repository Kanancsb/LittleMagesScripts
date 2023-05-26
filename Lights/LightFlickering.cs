using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D spotlight; // Reference to the 2D spotlight component
    public float minIntensity = 0.5f; // Minimum intensity for the flickering effect
    public float maxIntensity = 1f; // Maximum intensity for the flickering effect
    public float flickerSpeed = 5f; // Speed of the flickering effect

    private float randomOffset; // Random offset for the flickering effect

    void Start(){
        // Get the random offset to prevent all spotlights from flickering at the same time
        randomOffset = Random.Range(0f, 100f);
    }

    void Update(){
        // Calculate the flickering intensity using a sine wave
        float flickerIntensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong((Time.time + randomOffset) * flickerSpeed, 1f));

        // Set the spotlight intensity
        spotlight.intensity = flickerIntensity;
    }
}
