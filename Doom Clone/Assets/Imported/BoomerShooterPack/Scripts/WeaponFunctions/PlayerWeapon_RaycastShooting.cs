using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon_RaycastShooting : RaycastShooting
{
    [SerializeField] private WeaponStats stats;
    public void Fire(){
        Fire(ControllerReferences.player, stats);
    }
}
