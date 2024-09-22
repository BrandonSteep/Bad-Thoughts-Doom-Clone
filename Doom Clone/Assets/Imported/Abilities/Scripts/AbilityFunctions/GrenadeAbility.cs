using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/Grenade")]
public class GrenadeAbility : AbilitySO
{
    [SerializeField] private GameObject projectile;
    
    public override void Activate(){
        Vector3 startPosition = ControllerReferences.cam.transform.position + (ControllerReferences.cam.transform.forward * 1f);
        Vector3 startRotation = new Vector3(ControllerReferences.cam.transform.eulerAngles.x - 22.5f, ControllerReferences.player.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

        Debug.Log($"Throwing Grenade from {startRotation}");
        Instantiate(projectile, startPosition, Quaternion.Euler(startRotation));
    }
}
