using UnityEngine;

public class State
{
    public virtual void RunState(AIStateMachineManager sm){
        // Debug.Log("Running Empty State");
        sm.SetDestination(sm.transform.position);
    }

    public virtual void OnStateEntered(AIStateMachineManager sm){

    }
}
