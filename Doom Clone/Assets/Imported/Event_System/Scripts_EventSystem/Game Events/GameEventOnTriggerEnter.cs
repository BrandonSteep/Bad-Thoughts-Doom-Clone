using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventOnTriggerEnter : GameEventTrigger
{
    private Collider _coll;

    void OnEnable(){
        _coll = GetComponent<Collider>();
    }

    void OnTriggerEnter(){
        Debug.Log("Event Triggered On Trigger Enter");
        TriggerEvent();
    }
}
