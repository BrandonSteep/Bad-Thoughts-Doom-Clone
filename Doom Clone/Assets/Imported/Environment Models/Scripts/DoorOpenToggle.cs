using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenToggle : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _anim;

    void Start(){
        _anim = GetComponent<Animator>();
    }

    public void Interact(){
        _anim.SetTrigger("Toggle");
    }
}
