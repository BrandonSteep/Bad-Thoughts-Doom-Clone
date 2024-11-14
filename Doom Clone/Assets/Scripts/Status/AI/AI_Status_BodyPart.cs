using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Status_BodyPart : MonoBehaviour, IDamageable
{
    [SerializeField] private AI_Status mainStatus;
    
    public void TakeDamage(RaycastHit hit, float damageAmount, GameObject damageOrigin){
        mainStatus.TakeDamage(hit, damageAmount, damageOrigin);
    }
    public void TakeDamage(Transform other, float damageAmount, GameObject damageOrigin){
        mainStatus.TakeDamage(other, damageAmount, damageOrigin);
    }
}
