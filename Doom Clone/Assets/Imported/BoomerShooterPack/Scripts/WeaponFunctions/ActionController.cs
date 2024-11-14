using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private ScriptableVariable _currentAmmo;
    [SerializeField] private int _animNum;

    void Start(){
        _anim = GetComponent<Animator>();
    }

    public void Action(){
        if(_currentAmmo.value > 0){
            if(_animNum != 0){
                _anim.SetInteger("Random", Random.Range(0, _animNum));
            }
            _anim.SetTrigger("Fire");
        }
    }
}
