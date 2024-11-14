using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryReferences : MonoBehaviour
{
    public static InventoryReferences instance { get; private set; }

    public static ObjectPool objectPool;



    void Start()
    {
        instance = this;

        objectPool = GameObject.FindWithTag("ObjectPool").GetComponent<ObjectPool>();
    }
}
