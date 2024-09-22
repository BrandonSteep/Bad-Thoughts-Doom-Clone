using Unity.VisualScripting;
using UnityEngine;

public class AIAttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] private AI_RaycastShooting raycastShooting;

    [SerializeField] private Transform muzzle;

    // // Audio
    // [SerializeField] private AudioSource audioSource;
    // [SerializeField] private AudioClip lightSound;

    public void FireProjectile(){
        Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation).GetComponent<Projectile>();
        newProjectile.ProjectileSetup(this.gameObject);

        // audioSource.PlayOneShot(lightSound);
    }

    public void FireHitscan(){
        raycastShooting.FireFromMuzzle(this.gameObject, weaponStats);
    }

    public void TriggerProjectileAttack(){

    }

    public void TriggerMeleeAttack(){

    }
}
