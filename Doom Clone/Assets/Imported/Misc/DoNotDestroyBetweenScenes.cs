using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyBetweenScenes : MonoBehaviour
{
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
}
