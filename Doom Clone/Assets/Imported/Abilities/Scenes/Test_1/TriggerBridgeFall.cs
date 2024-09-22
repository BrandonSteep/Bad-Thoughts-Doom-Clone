using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridgeFall : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    
    public void Fall(){
        _anim.SetTrigger("Fall");
    }
}
