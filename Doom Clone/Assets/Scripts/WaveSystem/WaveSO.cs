using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Spawn")]
public class WaveSO : ScriptableObject
{
    [SerializeField] private GameObject[] gameObjectsToSpawn;
    [SerializeField] private int difficultyRating;

    public GameObject[] GetWave(){
        return gameObjectsToSpawn;
    }

    public int GetDifficultyRating(){
        return difficultyRating;
    }
}
