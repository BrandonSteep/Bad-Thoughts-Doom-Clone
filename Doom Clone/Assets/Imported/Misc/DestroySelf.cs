using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public void RemoveFromHierarchy(){
        Destroy(this.gameObject);
    }
}
