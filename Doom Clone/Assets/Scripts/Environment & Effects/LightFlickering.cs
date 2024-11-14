using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    private Light light;

    [SerializeField] private float minLightAmount = .66f;
    [SerializeField] private float maxLightAmount = 1.25f;
    [SerializeField] private float minLightSpeed = 0.025f;
    [SerializeField] private float maxLightSpeed = 0.5f;

    [SerializeField] private float minDarkAmount = .25f;
    [SerializeField] private float maxDarkAmount = .8f;
    [SerializeField] private float minDarkSpeed = 0.5f;
    [SerializeField] private float maxDarkSpeed = 1.5f;

    void OnEnable(){
        light = GetComponent<Light>();
        Invoke("DisableLight", Random.Range(minDarkSpeed, maxDarkSpeed));
    }

    private void EnableLight(){
        light.intensity = Random.Range(minLightAmount, maxLightAmount);

        // light.enabled = true;
        Invoke("DisableLight", Random.Range(minLightSpeed, maxLightSpeed));
    }
    private void DisableLight(){
        light.intensity = Random.Range(minDarkAmount, maxDarkAmount);

        // light.enabled = false;
        Invoke("EnableLight", Random.Range(minDarkSpeed, maxDarkSpeed));
    }
}
