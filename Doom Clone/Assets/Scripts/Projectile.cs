using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject origin;
    [SerializeField] private AIStats stats;
    [SerializeField] private ExplosiveStats explosiveStats;

    [SerializeField] private bool destroyOnContact = true;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask shootableLayers;

    [SerializeField] private GameObject splashParticle;

    // AOE Settings
    [SerializeField] private bool AOE = false;
    [SerializeField] private GameObject AOEHit;
    
    // // Effects
    // [SerializeField] private AudioClip hitSound;

    void OnEnable(){
        rb = GetComponent<Rigidbody>();
        Vector3 forward = this.transform.forward;
        if(!AOE){
            rb.AddForce(-forward * stats.GetProjectileSpeed(), ForceMode.Impulse);
        }
        else{
            rb.AddForce(forward * explosiveStats.GetProjectileSpeed(), ForceMode.Impulse);            
        }
        StartCoroutine("Timer");
    }

    public void ProjectileSetup(GameObject originObj){
        origin = originObj;
    }

    private void OnTriggerEnter(Collider other){
        // Debug.Log($"Projectile Collided with {other.gameObject.name}");
        if(destroyOnContact){
            if ((shootableLayers.value & (1<<other.gameObject.layer)) != 0){
                if(other.tag == "Player" && stats != null|| other.tag == "Enemy" && stats != null){
                    other.GetComponent<IDamageable>().TakeDamage(this.transform, stats.GetProjectileDamage(), origin);
                }
                DestroyProjectile();
            }
        }
    }

    public void DestroyProjectile(){
        // Instantiate(splashParticle, this.transform.position, Quaternion.identity);
        if(AOE){
            Instantiate(AOEHit, this.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

    private IEnumerator Timer(){
        if(explosiveStats != null){
            yield return new WaitForSeconds(explosiveStats.GetLifetime());
        }
        else{
            yield return new WaitForSeconds(stats.GetProjectileLifetime());
        }
        DestroyProjectile();
        yield return null;
    }
}
