using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustEnvironmentLightingValueOnTriggerEnter : MonoBehaviour
{
    private AdjustEnvironmentLightingIntensity adjustLighting = new AdjustEnvironmentLightingIntensity();
    [SerializeField] protected float duration;
    [SerializeField] protected float endValue;
    [SerializeField] protected AnimationCurve curve;
    
    void OnTriggerEnter(Collider other){
        // Debug.Log("TRIGGERED");
        if(other.gameObject == ControllerReferences.player){
            Debug.Log("Adjusting Lighting");
            StartCoroutine(adjustLighting.ChangeAmbientLighting(duration, endValue, curve));
        }
    }
}
