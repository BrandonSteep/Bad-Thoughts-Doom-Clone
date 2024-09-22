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

    void Start(){
        _weaponSlot = transform.GetChild(0).gameObject;
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

    private void DisableWeaponAnim(){
        _currentWeapon.GetComponent<Animator>().enabled = false;
    }
    public void EnableWeaponAnim(){
        _currentWeapon.GetComponent<Animator>().enabled = true;
    }

    public void PickupWeapon(int weaponIndex){
        hasWeapon[weaponIndex] = true;
    }
}
