using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepArray : SoundArray
{
    [SerializeField] private GameEvent _footstepEvent;

    public override void PlayRandom(){
        // if(ControllerReferences.characterController.isGrounded){
            _footstepEvent.Raise();
            base.PlayRandom();
        // }
    }
}
