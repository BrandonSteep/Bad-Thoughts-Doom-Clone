using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickups : MonoBehaviour, IInteractable
{
    [SerializeField] private BoomerShooterWeaponSystem equippedManager;
    [SerializeField] private int weaponIndex;
    [SerializeField] private AudioClip pickupSound;

    void Start(){
        Debug.Log($"Setting equippedManager as {ControllerReferences.equipmentManager}");
        equippedManager = ControllerReferences.equipmentManager;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject == ControllerReferences.player){
            Interact();
        }
    }

    public void Interact(){
        Debug.Log(equippedManager);
        equippedManager.PickupWeapon(weaponIndex);
        if(pickupSound != null){
            // Play Pickup Audio
        }
        
        Destroy(this.gameObject);
    }
}
