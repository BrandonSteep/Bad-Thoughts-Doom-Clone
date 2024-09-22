using UnityEngine;

public class AI_Status : Status, IDamageable
{
    [SerializeField] private AIStats stats;
    [SerializeField] private float currentHealth;

    void Awake(){
        currentHealth = stats.GetMaxHealth();
    }

    public void TakeDamage(RaycastHit hit, float damageAmount, GameObject attackOrigin){
        Debug.Log($"AI took {damageAmount} points of damage from {attackOrigin}");
        currentHealth -= damageAmount;
        
        if(currentHealth <= 0f){
            Die();
        }
    }

    public void TakeDamage(Transform other, float damageAmount, GameObject attackOrigin){
        Debug.LogWarning($"Player hit with projectile from {attackOrigin}, dealing {damageAmount} damage");
        if (canTakeDamage && isAlive){
            currentHealth -= damageAmount;
            
            if(currentHealth <= 0f){
                Die();
            }
            // else{
            //     AddIFrames(iFramesInSeconds);
            // }
        }
    }

    public void TakeDamage(Transform other, float damageAmount){
        Debug.Log($"AI took {damageAmount} points of damage");
        currentHealth -= damageAmount;
        
        if(currentHealth <= 0f){
            Die();
        }
    }
}
