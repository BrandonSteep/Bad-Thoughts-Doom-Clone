using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class ResistanceGuard_Status : AI_Status
{
    [SerializeField] private Animator anim;
    [SerializeField] private Component[] componentsToDestroyOnDeath;
    protected override void Die(){
        anim.SetTrigger("Die");
        isAlive = false;
        for(int i = 0; i < componentsToDestroyOnDeath.Length; i++){
            Destroy(componentsToDestroyOnDeath[i]);
        }
    }
}
