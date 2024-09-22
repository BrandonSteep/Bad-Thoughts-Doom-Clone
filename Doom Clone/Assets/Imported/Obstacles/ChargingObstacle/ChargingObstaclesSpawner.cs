using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private SpawnObject _spawner;
    [SerializeField] private float _minSpawnTimer = 1f;
    [SerializeField] private float _maxSpawnTimer = 3f;
    private int _slotPicked;
    private int _lastSlotPick = 10;

    void Start()
    {
        _spawner = GetComponent<SpawnObject>();
        RunSpawner();
    }
    
    private void RunSpawner(){
        Invoke("SpawnObstacle", Random.Range(_minSpawnTimer, _maxSpawnTimer));
    }

    private void SpawnObstacle(){
        _slotPicked = Random.Range(0, _spawner.spawnPoint.Length);
        if(_slotPicked == _lastSlotPick){
            _slotPicked = _slotPicked = Random.Range(0, _spawner.spawnPoint.Length-1);

        }
        _spawner.Spawn(0, _slotPicked);
        _lastSlotPick = _slotPicked;
        RunSpawner();
    }
}
