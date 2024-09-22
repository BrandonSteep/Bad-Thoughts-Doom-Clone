using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    protected bool isAlive = true;
    protected bool canTakeDamage = true;

    public bool CanTakeDamage(){
        return canTakeDamage;
    }

    protected virtual void Die(){
        isAlive = false;
        Destroy(this.gameObject);
    }

    public void AddIFrames(float iFrames){
        canTakeDamage = false;
        if(iFrames <= 0){
            Debug.Log($"iFrames not given - stat = {iFrames}");
        }
        else{
            Debug.Log($"iFrames = {iFrames}");

            canTakeDamage = false;
            Invoke("ResetDamage", iFrames);
        }
    }

    public void ResetDamage()
    {
        Debug.Log("iFrames Over");
        canTakeDamage = true;
    }
}