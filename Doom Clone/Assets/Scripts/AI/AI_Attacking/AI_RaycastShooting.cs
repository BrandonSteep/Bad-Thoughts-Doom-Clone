using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_RaycastShooting : RaycastShooting
{
    public void FireFromMuzzle(GameObject attackOrigin, WeaponStats stats){
        for(int i = stats.GetShotCount(); i > 0; i--){
                Vector3 shootDirection = -muzzle.transform.forward + stats.GetRandomSpread();
                shootDirection.Normalize();
                if(Physics.Raycast(muzzle.transform.position, shootDirection, out RaycastHit hit, float.MaxValue, hitLayers)){
                    if(stats.PlaysTrail()){
                        Trail(muzzle.position, -muzzle.transform.forward + (shootDirection * hit.distance));
                    }
                    InventoryReferences.objectPool.SpawnFromPool("HitGeneric", hit.point, Quaternion.LookRotation(hit.normal));

                    if(hit.collider.tag == "Player" || hit.collider.tag == "Enemy" || hit.collider.tag == "EnemySpawner"){
                        hit.collider.GetComponent<IDamageable>().TakeDamage(hit, stats.GetRandomDamage(), attackOrigin);;
                    }
            }
            else{
                if(stats.PlaysTrail()){
                    Trail(muzzle.position, -muzzle.transform.forward + (shootDirection * 100));
                }
            }
        }
    }
}
