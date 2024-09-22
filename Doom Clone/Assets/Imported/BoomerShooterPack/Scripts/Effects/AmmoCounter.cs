using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour{
    private Animator anim;
    [SerializeField] private ScriptableVariable currentAmmo;
    [SerializeField] private ScriptableVariable totalAmmo;
    [SerializeField] private ScriptableVariable maxAmmo;

    private bool isReloading;

    void OnEnable(){
        anim = GetComponent<Animator>();
    }

    public void ReduceCount(){
        currentAmmo.value--;
        CheckAmmo();
    }

    public void CheckAmmo(){
        if(currentAmmo.value <= 1){
            anim.SetBool("LastShot", true);
            CheckIfEmpty();
        }
    }

    public void CheckIfEmpty(){
        if(currentAmmo.value == 0){
            anim.SetBool("Empty", true);
        }
    }
    
    #region Reload
        public void ReloadWeapon(){
            if(currentAmmo.value < maxAmmo.value && totalAmmo.value > 0){
                isReloading = true;
                anim.SetTrigger("Reload");
                
                RemoveFireBuffer();
                ContinueReload();
            }
        }
    
        public void RefillAmmo(){
            int neededAmmo = (int)maxAmmo.value - (int)currentAmmo.value;
            int availableAmmo = Mathf.Min((int)totalAmmo.value, neededAmmo);
            currentAmmo.value += availableAmmo;
            totalAmmo.value -= availableAmmo;

            anim.SetBool("LastShot", false);

            // Debug.Log($"Current Ammo = {currentAmmo.value}");
            // Debug.Log($"Total Ammo = {totalAmmo.value}");
        }

        public void RefillAmmoIncrementally(){
            isReloading = true;
            
            int availableAmmo = Mathf.Min((int)totalAmmo.value, 1);
            currentAmmo.value += availableAmmo;
            totalAmmo.value -= availableAmmo;

            Debug.Log($"Current Ammo = {currentAmmo.value}");
                
            if(currentAmmo.value >= maxAmmo.value){
                CancelReload();
            }
        }

        public void RemoveReloadBuffer(){
            isReloading = false;
            anim.ResetTrigger("Reload");
        }

        public void RemoveFireBuffer(){
            anim.ResetTrigger("Fire");
        }

        public void CancelReload(){
            if(isReloading){
                Debug.Log("Cancel Reload");
                anim.SetTrigger("CancelReload");
                isReloading = false;
            }
        }

        public void ContinueReload(){
            anim.ResetTrigger("CancelReload");
        }

        public void FinishReload(){
            isReloading = false;
            RemoveReloadBuffer();
            RemoveFireBuffer();

            if(currentAmmo.value > 1){
                anim.SetBool("Empty", false);
            }
        }
    #endregion
}