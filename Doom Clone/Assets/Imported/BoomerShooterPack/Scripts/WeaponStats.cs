using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapons/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private GameObject weaponPrefab;
    
    [SerializeField] private float damageMin = 5f;
    [SerializeField] private float damageMax = 15f;

    [SerializeField] private int shotCount = 1;
    [SerializeField] private Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private int pierceAmount = 0;
    [SerializeField] private bool playTrail = true;
    [SerializeField] private GameObject weaponRagdoll;

    #region Return Functions

    public GameObject GetPrefab(){
        return weaponPrefab;
    }

    public float GetRandomDamage(){
        return Random.Range(damageMin, damageMax);
    }

    public float GetDamageMin(){
        return damageMin;
    }

    public float GetDamageMax(){
        return damageMax;
    }

    public int GetShotCount(){
        return shotCount;
    }

    public Vector3 GetRandomSpread(){
        return new Vector3(Random.Range(spread.x, -spread.x), Random.Range(spread.y, -spread.y), Random.Range(spread.z, -spread.z));
    }

    public int GetPierceAmount(){
        return pierceAmount;
    }

    public bool PlaysTrail(){
        return playTrail;
    }

    public GameObject GetWeaponRagdoll(){
        return weaponRagdoll;
    }

#endregion
    
}
