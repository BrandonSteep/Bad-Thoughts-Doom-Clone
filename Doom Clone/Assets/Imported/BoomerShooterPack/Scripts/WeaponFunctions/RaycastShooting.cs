using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] protected LayerMask hitLayers;
    [SerializeField] protected Transform muzzle;

    [SerializeField] private GameObject bloodSpatter;

    public virtual void Fire(GameObject attackOrigin, WeaponStats stats){
            for(int i = stats.GetShotCount(); i > 0; i--){
                Vector3 shootDirection = Camera.main.transform.forward + stats.GetRandomSpread();
                shootDirection.Normalize();
                if(Physics.Raycast(Camera.main.transform.position, shootDirection, out RaycastHit hit, float.MaxValue, hitLayers)){
                    if(stats.PlaysTrail()){
                        Trail(muzzle.position, Camera.main.transform.forward + (shootDirection * hit.distance));
                    }
                    InventoryReferences.objectPool.SpawnFromPool("HitGeneric", hit.point, Quaternion.LookRotation(hit.normal));

                    if(hit.collider.tag == "Enemy" || hit.collider.tag == "EnemySpawner"){
                        
                        hit.collider.GetComponent<IDamageable>().TakeDamage(hit, stats.GetRandomDamage(), attackOrigin);;
                        Instantiate(bloodSpatter, hit.point, Quaternion.LookRotation(hit.normal));
                        
                        // if(_pierceAmount > 0){
                        //     Ray ray = new Ray(Camera.main.transform.position + shootDirection * Mathf.Infinity, Camera.main.transform.forward);
                        //     Pierce(hit, ray);
                        // }
                    }
                }
                else{
                    if(stats.PlaysTrail()){
                        Trail(muzzle.position, Camera.main.transform.forward + (shootDirection * 100));
                    }
                }
            }
    }

    protected virtual void Pierce(RaycastHit firstHit, Ray ShootRay, WeaponStats stats, GameObject attackOrigin){
        RaycastHit lastHit = firstHit;
        RaycastHit nextHit;
        for(int i = 0; i < stats.GetPierceAmount(); i++){


                if(Physics.Raycast(lastHit.point, ShootRay.direction, out nextHit, Mathf.Infinity)){
                    if(stats.PlaysTrail()){
                        Trail(lastHit.point, nextHit.point);
                    }
                    InventoryReferences.objectPool.SpawnFromPool("HitGeneric", nextHit.point, Quaternion.FromToRotation(Vector3.forward, nextHit.normal));
                    
                    if(nextHit.collider.tag == "Enemy" || nextHit.collider.tag == "EnemySpawner"){
                        nextHit.collider.GetComponent<IDamageable>().TakeDamage(nextHit, stats.GetRandomDamage(), attackOrigin);
                        Instantiate(bloodSpatter, nextHit.point, Quaternion.LookRotation(nextHit.normal));
                    }

                    lastHit = nextHit;
                }
                // else{
                //     if(_playTrail){
                //         Trail(lastHit.point, nextHit.point);
                //     }
                // }
            
        }
    }

    protected void Trail(Vector3 spawnPosition, Vector3 endPoint){
        
        GameObject bulletTrailEffect = InventoryReferences.objectPool.SpawnFromPool("BulletTrail", spawnPosition, Quaternion.identity);

        LineRenderer line = bulletTrailEffect.GetComponent<LineRenderer>();

        line.SetPosition(1, endPoint);

        StartCoroutine(DestroyTrail(bulletTrailEffect));
    }

    private IEnumerator DestroyTrail(GameObject trail)
    {
        yield return new WaitForSeconds(1f);
        trail.SetActive(false);
    }
}
