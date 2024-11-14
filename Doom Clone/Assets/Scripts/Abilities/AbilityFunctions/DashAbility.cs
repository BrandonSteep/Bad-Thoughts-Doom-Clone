using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/Dash")]
public class DashAbility : AbilitySO
{
    [SerializeField] private float _dashForce;
    [SerializeField] private Vector3SO _horizontalInput;
    private Vector3 _dashDirection;

    public override void Activate(){
        Debug.Log("Dashing");
        ControllerReferences.playerController.velocityY = 0f;
        if(_horizontalInput.value == Vector3.zero){
            _dashDirection = ControllerReferences.player.transform.forward;
        }
        else{
            _dashDirection = ControllerReferences.player.transform.forward * _horizontalInput.value.y + ControllerReferences.player.transform.right * _horizontalInput.value.x;
        }
        
        ControllerReferences.playerKnockback.AddImpact(_dashDirection, _dashForce);
    }
}
