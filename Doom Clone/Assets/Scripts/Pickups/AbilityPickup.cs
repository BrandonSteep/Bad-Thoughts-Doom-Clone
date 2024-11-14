using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private AbilitySO _abilityToPickUp;
    
    // [SerializeField] private AudioClip _pickupSound;
    // [SerializeField] private AudioSource _aSource;

    public void Interact(){
        ControllerReferences.abilityHolder._newAbility = _abilityToPickUp;
        ControllerReferences.abilityHolder.EquipAbility();
        // if(_pickupSound != null){
        //     _aSource.PlayOneShot(_pickupSound);
        // }
    }
}
