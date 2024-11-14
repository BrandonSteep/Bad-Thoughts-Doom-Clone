using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThought_Status : AI_Status
{
    [SerializeField] private GameObject deathExplosion;
    protected override void Die(){
        Instantiate(deathExplosion, this.transform.GetChild(0).transform.position, Quaternion.identity);
        base.Die();
    }
}
