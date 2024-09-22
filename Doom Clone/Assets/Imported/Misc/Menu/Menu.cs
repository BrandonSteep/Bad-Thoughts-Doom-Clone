using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour

{
[SerializeField] private GameObject _menu;
[SerializeField] private ScriptableVariable _sensitivity;
[SerializeField] private GameEvent _sensChange;
[SerializeField] private Slider slider;

    public void ToggleMenu(){
        Cursor.visible = !Cursor.visible;
    Cursor.lockState = CursorLockMode.Locked;
        _menu.SetActive(!_menu.activeInHierarchy);
        
        if(_menu.activeInHierarchy){
            Cursor.lockState = CursorLockMode.Confined;
        }
}

    public void SetSensitivity(){
        _sensitivity.value = slider.value;
        _sensChange.Raise();
    }
}
