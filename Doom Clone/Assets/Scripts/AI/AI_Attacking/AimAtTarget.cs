using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    [SerializeField] private AIStateMachineManager sm;
    [SerializeField] private bool inverted;
    // [SerializeField] private float minXClamp = 0f;
    // [SerializeField] private float maxXClamp = 0f;

    void Awake(){
        if(!sm){
            sm = GetComponentInParent<AIStateMachineManager>();
        }
        InvokeRepeating("Look", 0f, 0.1f);
    }    

    private void Look(){
        if(sm.GetTarget() != null){
            transform.LookAt(2 * transform.position - sm.GetTarget().transform.position);
        }
    }
}
