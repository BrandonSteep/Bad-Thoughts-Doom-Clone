using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine_VoidGhost : AIStateMachineManager
{
    [SerializeField] private Animator anim;

    public override void RangedAttack(){
        anim.SetTrigger("Fire");
    }
}
