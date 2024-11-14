using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour, IInteractable
{
    [Header ("Functionality")]
    [SerializeField] private GameObject[] objToSpawn;
    public Transform[] spawnPoint;
    
    private int objArrayLength;
    private int spawnPointArrayLength;

    private GameObject _spawned;

    [Header("Effects")]
    [SerializeField] private MeshRenderer rend;
    [SerializeField] private Material white;
    [SerializeField] private Material blue;

    [SerializeField] private AudioClip aClip;

    void Awake(){
        rend = GetComponent<MeshRenderer>();

        objArrayLength = objToSpawn.Length;
        spawnPointArrayLength = spawnPoint.Length;

    }

    public void Interact(){
        Debug.Log($"Interacting with {this.gameObject.name}");
        
        if(_spawned != null){
            Destroy(_spawned);
        }

        Spawn(ChooseFromArray(objArrayLength), ChooseFromArray(spawnPointArrayLength));

        rend.material = blue;

        if(aClip != null){
            var aSource = this.gameObject.AddComponent<AudioSource>();
            aSource.pitch = Random.Range(0.95f, 1.05f);
            aSource.PlayOneShot(aClip, 0.6f);
            Destroy(aSource, 1.5f);
        }

        Invoke("ChangeColourBack", 0.25f);
    }

    public void Spawn(int objNum, int spawnNum){
        _spawned = Instantiate(objToSpawn[objNum], spawnPoint[spawnNum]);
    }

    private int ChooseFromArray(int i){
        if (i <= 0) {
            Debug.LogError("Array is empty");
            return 0;
        } else {
            return Random.Range(0, i);
        }
    }

    private void ChangeColourBack(){
        rend.material = white;
    }
}
