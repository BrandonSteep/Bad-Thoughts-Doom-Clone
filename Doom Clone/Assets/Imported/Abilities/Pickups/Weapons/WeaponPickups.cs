using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickups : MonoBehaviour, IInteractable
{
    private BoomerShooterWeaponSystem equippedManager;
    [SerializeField] private int weaponIndex;
    [SerializeField] private AudioClip pickupSound;

    void Start(){
        equippedManager = ControllerReferences.equipmentManager;
    }

    public void Interact(){
        equippedManager.PickupWeapon(weaponIndex);
        if(pickupSound != null){
            // Play Pickup Audio
        }
        
        Destroy(this.gameObject);
    }
}
