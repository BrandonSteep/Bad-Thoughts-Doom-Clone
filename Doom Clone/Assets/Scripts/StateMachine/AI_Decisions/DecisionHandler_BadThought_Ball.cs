using UnityEngine;
public class DecisionHandler_BadThought_Ball : IDecisionHandler
{
    // State References //
    private State stateStay = new State();

    private State currentMoveState = new State_ChaseDirect();
    private State stateChaseDirect = new State_ChaseDirect();
    private State stateStrafeLeft = new State_StrafeLeft();
    private State stateStrafeRight = new State_StrafeRight();

    // Misc Variables //
    private bool targetSeen;
 
    public State MakeAIDecisions(AIStateMachineManager sm){
        SetTargetSeen(sm);
        // Debug.Log($"Running State & Change Movement = {sm.ChangeMovement()} & Aware of Target = {sm.AwareOfTarget()}");

        if(sm.ChangeMovement()){
            Debug.Log("Changing Movement Pattern");
            currentMoveState = ChooseMovementType(sm);
        }
        if(!sm.AwareOfTarget()){
            return stateStay;
        }
        else{
            return currentMoveState;
        }
        
    }

    protected virtual State ChooseMovementType(AIStateMachineManager sm){
        int randomChoice = Random.Range(0,15);
        if(randomChoice <= 4){
            if(CheckDistance(sm.transform.position, sm.GetTarget().transform.position) < sm.GetMeleeDistance()){
                Debug.Log("Chasing down to kill Player");
                return stateChaseDirect;
            }
            Debug.Log("Move Left");
            return stateStrafeLeft;
        }
        else if(randomChoice > 3 && randomChoice <= 7){
            if(CheckDistance(sm.transform.position, sm.GetTarget().transform.position) < sm.GetMeleeDistance()){
                Debug.Log("Chasing down to kill Player");
                return stateChaseDirect;
            }
            Debug.Log("Move Right");
            return stateStrafeRight;
        }
        else{
            Debug.Log("Move to Player");
            return stateChaseDirect;
        }
    }

    private void SetTargetSeen(AIStateMachineManager sm){
        targetSeen = sm.GetFieldOfView();
        // Debug.Log($"Target Seen = {targetSeen}");
        if(targetSeen && !sm.AwareOfTarget()){
            sm.TargetFound();
        }
    }

    private float CheckDistance(Vector3 a, Vector3 b){
        return Vector3.Distance(a, b);
    }
}
