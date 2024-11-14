using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject itemDrop;
    [SerializeField] private Transform spawnPoint;
    
    public void SpawnItem(){
        Instantiate(itemDrop, spawnPoint.position, Quaternion.identity);
    }
}
