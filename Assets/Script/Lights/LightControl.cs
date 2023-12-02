using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public Light[] lights;
    private bool isLightOn = true;
    private float blinkInterval = 1.0f; // Adjust this interval as needed
    private float timer = 0.0f;

    void Start()
    {
        timer = blinkInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ToggleLights();
            timer = blinkInterval;
        }
    }

    private void ToggleLights()
    {
        isLightOn = !isLightOn;

        foreach (Light light in lights)
        {
            light.enabled = isLightOn;
        }
    }
}
