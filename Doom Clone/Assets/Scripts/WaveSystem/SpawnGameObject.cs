using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector3 spawnOffset;

    protected virtual void Spawn(){
        Instantiate(objectToSpawn, this.transform.position + spawnOffset, this.transform.rotation);
        OnSpawn();
    }

    protected virtual void OnSpawn(){}
}
