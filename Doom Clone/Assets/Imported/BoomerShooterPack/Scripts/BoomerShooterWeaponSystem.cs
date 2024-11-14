using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerShooterWeaponSystem : MonoBehaviour
{
    public GameObject _weaponSlot;

    [SerializeField] private GameObject _currentWeapon;
    [SerializeField] private GameEvent _swapAnimation;

    [SerializeField] private WeaponStats[] _availableWeapons;
    
    [SerializeField] private int _currentWeaponIndex = 0;
    [SerializeField] private int _nextWeaponIndex = 0;

    public bool _swapping = false;

    [SerializeField] private bool[] hasWeapon;

    [SerializeField] private GameObject blankWeapon;

    void Start(){
        _weaponSlot = transform.GetChild(0).gameObject;

        // Check for first Weapon in Inventory
        HasWeaponAtIndex firstWeapon = FirstWeaponInInventory();
        if(firstWeapon.HasWeapon()){
            // Debug.Log($"Has weapon at index {firstWeapon.GetIndex()} - Instantiating now");
            Instantiate(_availableWeapons[firstWeapon.GetIndex()].GetPrefab(), _weaponSlot.transform);
        }
        else{
            Debug.Log($"No Weapon in Inventory - Instantiate Blank");
            UnequipWeapon();
        }
        
        RefreshActiveWeapon();
    }

    private void RefreshActiveWeapon(){
        Debug.Log($"Refreshing - Current Weapon = {_weaponSlot.transform.GetChild(0).gameObject}");
        _currentWeapon = _weaponSlot.transform.GetChild(0).gameObject;
        _currentWeaponIndex = _nextWeaponIndex;
        
        EnableWeaponAnim();
    }

    public void SwapInputRecieved(){
        if(_currentWeaponIndex != _nextWeaponIndex){
            DisableWeaponAnim();
            _swapAnimation.Raise();
        }
    }

    public void SelectNextWeapon(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[_nextWeaponIndex+1]){
            _nextWeaponIndex ++;
            SwapInputRecieved();
        }
    }

    public void SelectSlot1(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[0]){
            _nextWeaponIndex = 0;
            SwapInputRecieved();
        }
    }
    public void SelectSlot2(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[1]){
            _nextWeaponIndex = 1;
            SwapInputRecieved();
        }
    }
    public void SelectSlot3(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[2]){
            _nextWeaponIndex = 2;
            SwapInputRecieved();
        }
    }
    public void SelectSlot4(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[3]){
            _nextWeaponIndex = 3;
            SwapInputRecieved();
        }
    }
    public void SelectSlot5(){
        if(_currentWeapon.GetComponent<SwappableStatus>()._canSwap && !_swapping && hasWeapon[4]){
            _nextWeaponIndex = 4;
            SwapInputRecieved();
        }
    }

    public void UnequipWeapon(){
        Instantiate(blankWeapon, _weaponSlot.transform);
        _nextWeaponIndex = 99;
    }

    public void SwapWeapons(){
        Destroy(_currentWeapon);
        if(_nextWeaponIndex >= 0 && _nextWeaponIndex < _availableWeapons.Length)
        {
            Instantiate(_availableWeapons[_nextWeaponIndex].GetPrefab(), _weaponSlot.transform);
        }
        else{
            _nextWeaponIndex = 0;
            Instantiate(_availableWeapons[0].GetPrefab(), _weaponSlot.transform);
        }
        // RefreshActiveWeapon();
        Invoke("RefreshActiveWeapon", 0.05f);
    }

    public void ThrowWeapon(){
        Rigidbody rb = Instantiate(_availableWeapons[_currentWeaponIndex].GetWeaponRagdoll(), _weaponSlot.transform.position, _weaponSlot.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(ControllerReferences.cam.transform.forward * 5f, ForceMode.Impulse);
        rb.AddTorque(new Vector3(10f,10f,10f));
        Destroy(_currentWeapon);
    }

    private void DisableWeaponAnim(){
        _currentWeapon.GetComponent<Animator>().enabled = false;
    }
    public void EnableWeaponAnim(){
        _currentWeapon.GetComponent<Animator>().enabled = true;
    }

    private HasWeaponAtIndex FirstWeaponInInventory(){
        for(int i = 0; i < hasWeapon.Length; i++){
            if(hasWeapon[i]){
                return new HasWeaponAtIndex(i, true);
            }
            else continue;
        }
        return new HasWeaponAtIndex(0, false);
    }

    public void PickupWeapon(int weaponIndex){
        hasWeapon[weaponIndex] = true;
    }
}
