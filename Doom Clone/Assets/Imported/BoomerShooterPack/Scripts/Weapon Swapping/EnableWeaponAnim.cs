using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWeaponAnim : MonoBehaviour
{
    [SerializeField] private GameEvent _enableWeaponAnim;

    public void EnableCurrentWeapon(){
        _enableWeaponAnim.Raise();
    }
}
