using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine_BadThought_Ball : AIStateMachineManager
{
    void OnEnable(){
        decisionHandler = new DecisionHandler_BadThought_Ball();
    }
}
