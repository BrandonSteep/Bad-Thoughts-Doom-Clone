using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedCamAsEventCamera : MonoBehaviour
{
    [SerializeField] private Canvas _sliderCanvas;

    void OnEnable()
    {
        _sliderCanvas.worldCamera = Camera.main.transform.GetChild(0).GetComponent<Camera>();
    }
}