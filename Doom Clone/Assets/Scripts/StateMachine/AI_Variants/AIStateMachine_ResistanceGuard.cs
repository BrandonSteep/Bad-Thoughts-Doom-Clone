using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine_ResistanceGuard : AIStateMachineManager
{
    [SerializeField] private Animator anim;
    [SerializeField] private SoundArray sounds;

    void OnEnable(){
        decisionHandler = new DecisionHandler_ResistanceGuard();
        sounds = GetComponent<SoundArray>();
    }

    public override void Idle(){
        anim.SetBool("PlayerSeen", false);
        base.Idle();
    }

    public override void TargetFound()
    {
        anim.SetBool("PlayerSeen", true);
        sounds.PlaySound(3);
        base.TargetFound();
    }

    public override void RangedAttack(){
        anim.SetTrigger("Fire");
    }
}
