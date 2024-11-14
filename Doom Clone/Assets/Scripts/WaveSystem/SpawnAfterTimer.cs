using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterTimer : SpawnGameObject
{
    [SerializeField] private float spawnTimer;
    [SerializeField] bool destroyOnSpawn = true;

    void OnEnable(){
        Invoke("Spawn", spawnTimer);
    }

    protected override void OnSpawn()
    {
        if(destroyOnSpawn){
            Destroy(this.gameObject);
        }
    }
}