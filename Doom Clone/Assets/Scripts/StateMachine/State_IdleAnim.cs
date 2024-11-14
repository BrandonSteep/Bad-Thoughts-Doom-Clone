using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_IdleAnim : State
{
    public override void OnStateEntered(AIStateMachineManager sm){
        sm.Idle();
    }

    public override void RunState(AIStateMachineManager sm){
        
    }
}
