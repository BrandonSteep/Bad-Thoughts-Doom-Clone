using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/Flashlight")]
public class FlashlightAbility : AbilitySO
{
    [SerializeField] private GameObject _flashlightGO;
    private GameObject _flashlight;

    public override void Activate()
    {
        Debug.Log("Flashlight Activated");
        HandleFlashlight();
    }

    #region Flashlight Logic
    void HandleFlashlight(){
        if(_flashlight == null){
            _flashlight = Instantiate(_flashlightGO, GameObject.FindWithTag("Ability").transform);
        }
        else{
            Destroy(_flashlight);
        }
    }

    #endregion
}
