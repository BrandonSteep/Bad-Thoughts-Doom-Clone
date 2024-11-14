using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float waveTimer = 25f;
    [SerializeField] private float firstWaveDelay = 10f;
    [SerializeField] private bool randomSpawns = false;
    [SerializeField] private WaveSO[] wavesInOrder;
    [SerializeField] private WaveSO[] extraWaves;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int waveNumber = 0;

    [SerializeField] private bool spawnByDifficulty = false;
    [SerializeField] private int difficultyModifier = 0;
    private int waveDifficulty = 0;

    [SerializeField] private GameEvent waveEvent;

    void OnEnable(){
        if(randomSpawns){
            InvokeRepeating("SpawnRandomWave", firstWaveDelay, 15f);
        }
        else{
            InvokeRepeating("SpawnWavesByCount", firstWaveDelay, waveTimer);
        }
    }

    private Transform ChooseSpawnPoint(){
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    public void SpawnNewWave(WaveSO waveToSpawn){
        for(int i = 0; i<waveToSpawn.GetWave().Length; i++){
            GameObject itemToSpawn = waveToSpawn.GetWave()[i];
            Instantiate(itemToSpawn, ChooseSpawnPoint().position, Quaternion.identity);
        }
    }

    private void SpawnWavesByCount(){
        waveEvent.Raise();

        waveNumber++;
        Debug.Log($"Wave Number = {waveNumber}");

        if(waveNumber < wavesInOrder.Length && !spawnByDifficulty){
            SpawnNewWave(wavesInOrder[waveNumber]);
        }
        else{
            if(waveNumber >= wavesInOrder.Length){
                waveNumber = 0;
            }
            waveDifficulty = 0;
            spawnByDifficulty = true;

            SpawnNewWave(wavesInOrder[waveNumber]);
            waveDifficulty += wavesInOrder[waveNumber].GetDifficultyRating();
            difficultyModifier++;
            
            while(waveDifficulty < difficultyModifier){
                Debug.Log($"Current Wave Difficulty = {waveDifficulty} & Current Difficulty = {difficultyModifier}");
                SpawnWavesByDifficulty(extraWaves[waveNumber]);
            }
        }
    }

    private void SpawnWavesByDifficulty(WaveSO waveSpawned){
        WaveSO newWave = extraWaves[Random.Range(0, wavesInOrder.Length)];
        SpawnNewWave(newWave);
        waveDifficulty += newWave.GetDifficultyRating();
    }

    private void SpawnRandomWave(){
        waveEvent.Raise();
        SpawnNewWave(wavesInOrder[Random.Range(0, wavesInOrder.Length)]);
    }

    public Transform[] GetSpawnPoints(){
        return spawnPoints;
    }
}
