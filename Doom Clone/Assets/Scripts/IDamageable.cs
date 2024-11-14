using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable{
    public void TakeDamage(float damageAmount){}
    public void TakeDamage(RaycastHit hit, float damageAmount, GameObject damageOrigin){}
    public void TakeDamage(Transform other, float damageAmount, GameObject damageOrigin){}
    public void Die(){}
}
