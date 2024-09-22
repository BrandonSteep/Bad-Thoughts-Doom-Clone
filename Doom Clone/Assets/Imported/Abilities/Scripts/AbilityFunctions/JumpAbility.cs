using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/Jump")]
public class JumpAbility : AbilitySO
{

    [SerializeField] private bool _canJump;
    [SerializeField] float jumpForce = 125f;
    
    [SerializeField] float jumpBufferTime = 0.2f;
    private float jumpBufferCurrent = 0f;
    [SerializeField] float fallMultiplier = 2.5f;

    public override void Activate()
    {
        Debug.Log("Jump Activated");
        jumpBufferCurrent = jumpBufferTime;
        HandleJump();
    }

    #region Jump Logic

    public override void RunScript(){
        if(ControllerReferences.playerController.controller.isGrounded){
            ResetJump();
        }
    }

    void HandleJump()
    {
        jumpBufferCurrent -= Time.deltaTime;

        if (jumpBufferCurrent > 0 && _canJump)
        {
            _canJump = false;
            // Debug.Log("Jump");
            ControllerReferences.playerController.velocityY = 0f;
            ControllerReferences.playerKnockback.AddImpact(Vector3.up, jumpForce);
        }
    }

    void BetterJump()
    {
        if(ControllerReferences.playerController.controller.velocity.y < -1.5 && !ControllerReferences.playerController.controller.isGrounded)
        {
            ControllerReferences.playerController.velocityY += ControllerReferences.playerController.gravity * fallMultiplier / 10f;
        }
    }

    void ResetJump()
    {
        if (!_canJump)
        {
            _canJump = true;
        }
    }

    #endregion
}
