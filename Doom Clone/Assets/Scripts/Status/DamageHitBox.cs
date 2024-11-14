using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitBox : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;

    void OnTriggerEnter(Collider other){
        if(other.gameObject == ControllerReferences.player){
            ControllerReferences.playerStatus.TakeDamage(this.transform, Random.Range(stats.GetDamageMin(), stats.GetDamageMax()), this.gameObject);
        }
    }
}
