using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachineManager : MonoBehaviour
{
    [SerializeField] private GameObject masterObject;
    [SerializeField] private GameObject target;
    [SerializeField] private bool awareOnAwake = false;
    
    private bool awareOfTarget = false;

    [SerializeField] private float runStateInterval = 0.2f;
    
    [SerializeField] private NavMeshAgent nav;

    // These can be changed on a per-enemy basis for increased behavioural variety
    [Header ("Handler Classes")]
    protected IDecisionHandler decisionHandler = new DecisionHandler();
    private FieldOfView fov;
    [SerializeField] private AIAttackHandler attackHandler;
    
    [SerializeField] private State currentState;
    private State nextState;
    protected State startState;

    private Coroutine smoothMove;

    

    private Coroutine movementTimerCoroutine;
    private Coroutine attackTimerCoroutine;

    [Header ("Movement Variables")]
    private float currentMovementTimer;
    private float movementTimer;
    private bool canMove = true;

    [Header ("Attack Variables")]
    private float currentAttackTimer;
    private float attackTimer;
    
    // Variables to be moved to AIState Class
    [SerializeField] private AIStats stats;
    // [SerializeField] private bool ambush;
    
    #region Core Functionality
    void Start(){
        if(!masterObject){
            masterObject = this.gameObject;
        }
        if(!nav){
            nav = masterObject.GetComponent<NavMeshAgent>();
        }
        if(target == null){
            ChangeTarget(ControllerReferences.player);
        }
        if(!attackHandler){
            attackHandler = GetComponent<AIAttackHandler>();
        }
        if(startState != null){
            currentState = startState;
        }
        if(!fov){
            fov = GetComponent<FieldOfView>();
        }

        InvokeRepeating("MakeAIDecisions", 0f, runStateInterval);
        InvokeRepeating("RunState", 0f, runStateInterval);

        if(awareOnAwake){
            TargetFound();
        }
    }

    private void RunState(){
        currentState.RunState(this);
        // Debug.Log($"Current State = {currentState}");
    }

    protected virtual void MakeAIDecisions(){
        nextState = decisionHandler.MakeAIDecisions(this);
        if(nextState != currentState){
            TransitionState(nextState);
        }
    }
#endregion

    #region Change Methods

    public void TransitionState(State newState){
        if(newState == null){
            // Debug.LogWarning("New State Null");
            return;
        }
        else if(newState != null && newState != currentState){
            currentState = newState;
            currentState.OnStateEntered(this);
        }
    }
    
    public void SetDestination(Vector3 pos){
        nav.SetDestination(pos);
    }

    public NavMeshPath CalculatePath(Vector3 pos){
        NavMeshPath path = new NavMeshPath();
        nav.CalculatePath(pos, path);

        return path;
    }

    public virtual void TargetFound(){
        if(!awareOfTarget){
            awareOfTarget = true;
            StartMovementTimer();
            StartAttackTimer();
        }
    }

    public virtual void TargetLost(){
        awareOfTarget = false;
        StopAllCoroutines();
    }

    public void ChangeTarget(GameObject newTarget){
        target = newTarget;
    }
    
    private void DisableNavMeshRotation(){
        nav.updateRotation = false;
    }

    private void EnableNavMeshRotation(){
        nav.updateRotation = true;
    }

#endregion

    #region Movement

    public virtual void Idle(){
        SetDestination(this.transform.position);
    }

    public bool ChangeMovement(){
        if(movementTimer >= 1f){
            StartMovementTimer();
            return true;
        }
        else return false;
    }

    public void StartMovementTimer(){
        currentMovementTimer = UnityEngine.Random.Range(stats.GetMovementInterval().x, stats.GetMovementInterval().y);

        if(movementTimerCoroutine != null){
            StopCoroutine(movementTimerCoroutine);
        }
        movementTimerCoroutine = StartCoroutine(RunTimer(currentMovementTimer, result => movementTimer = result));
    }

    public void StopMoving(){
        canMove = false;
    }

    public void StartMoving(){
        canMove = true;
    }

    public bool CanMove(){
        return canMove;
    }

#endregion

    #region Attack

    public virtual bool TryAttack(){
        if(attackTimer >= 1f){
            // Debug.Log("ATTACKING");
            StartAttackTimer();
            return true;
        }
        else return false;
    }

    public void StartAttackTimer(){
        currentAttackTimer = UnityEngine.Random.Range(stats.GetAttackInterval().x/* * difficultyModifier */, stats.GetAttackInterval().y/* *difficultyModifier */);
        
        if(attackTimerCoroutine != null){
            StopCoroutine(attackTimerCoroutine);
        }
        attackTimerCoroutine = StartCoroutine(RunTimer(currentAttackTimer, result => attackTimer = result));
    }

    public virtual void RangedAttack(){
        if(!stats.IsHitscan()){
            attackHandler.FireProjectile();
        }
        else{
            attackHandler.FireHitscan();
        }
    }

    public virtual void MeleeAttack(){
        Debug.LogWarning("No Melee Attack Set Up");
        // Initiate Melee Attack //
    }

#endregion

    #region Misc Functions

    public IEnumerator RunTimer(float endTime, Action<float> valueToSet){
        var t = 0f;
        while(t < 1f){
            t += Time.deltaTime / endTime;
            
            valueToSet(t);
            yield return null;
        }
        t = 1f;
        valueToSet(1f);
    }
    
    public void FacePlayer(){
        DisableNavMeshRotation();
        var lookPos = transform.position - GetTarget().transform.position;
        lookPos.y = 0f;
        if(smoothMove == null){
            smoothMove = StartCoroutine(TurnToFacePlayer(lookPos));
        }
        else{
            StopCoroutine(smoothMove);
            smoothMove = StartCoroutine(TurnToFacePlayer(lookPos));
        }
    }

    public IEnumerator TurnToFacePlayer(Vector3 lookPos){
        
        Quaternion currentRot = transform.rotation;
        Quaternion rotation = Quaternion.LookRotation(-lookPos);

        float counter = 0;
        while (counter < GetRunStateInterval()){
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(currentRot, rotation, counter / GetRunStateInterval());
            yield return null;
        }
        EnableNavMeshRotation();
    }

#endregion

    #region Return Functions

    public GameObject GetTarget(){
        return target;
    }

    public bool AwareOfTarget(){
        return awareOfTarget;
    }

    public float GetRunStateInterval(){
        return runStateInterval;
    }

    public bool GetFieldOfView(){
        return fov.CheckFOV(this);
    }

    public float GetMeleeDistance(){
        return stats.GetMeleeDistance();
    }
    
#endregion

}
