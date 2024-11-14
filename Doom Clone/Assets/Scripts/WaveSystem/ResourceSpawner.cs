using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 10f;
    [SerializeField] private float spawnChancePercentage = 20f;
    [SerializeField] private GameObject stimPack;
    [SerializeField] private GameObject medKit;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<GameObject> spawnedResources = new List<GameObject>();

    void Awake(){
        InvokeRepeating("SpawnMedsDecision", spawnTimer, spawnTimer);
    }

    public void OnWaveSpawn(){
        if(spawnedResources.Count <= 5){
            SpawnMedsDecision();
        }
    }

    private void SpawnMedsDecision(){
            if(ControllerReferences.playerStatus.currentHp.value < 75f && ControllerReferences.playerStatus.currentHp.value > 35f){
                float randomValue = Random.Range(0, 100);
                if(randomValue <= spawnChancePercentage){
                    SpawnItem(stimPack);
                }
            }
            else if(ControllerReferences.playerStatus.currentHp.value <= 35f){
                float randomValue = Random.Range(0, 100);
                if(randomValue <= spawnChancePercentage){
                    SpawnItem(medKit);
                }
            }
    }

    private void SpawnAmmoDecision(){

    }

    private void SpawnItem(GameObject itemToSpawn){
        Debug.Log($"Spawning {gameObject.name}");

        GameObject recentlySpawned = Instantiate(itemToSpawn, ChooseSpawnPoint(Random.Range(0, spawnPoints.Length)).position, Quaternion.identity);
        spawnedResources.Add(recentlySpawned);
        StartCoroutine(DestroyAfterTime(recentlySpawned));
    }

    private Transform ChooseSpawnPoint(int spawnPointIndex){
        var newSpawnPoint = spawnPoints[spawnPointIndex];
        Collider[] hitColliders = Physics.OverlapSphere(newSpawnPoint.position, 1f);
        foreach (var other in hitColliders){
            if(other.tag == "Pickup"){
                return ChooseSpawnPoint(spawnPointIndex+1);
            }
            else return newSpawnPoint;
        }
        return newSpawnPoint;
    }

    private IEnumerator DestroyAfterTime(GameObject goToDestroy){
        yield return new WaitForSeconds(30f);
        spawnedResources.Remove(goToDestroy);
        Destroy(goToDestroy);
    }
}
