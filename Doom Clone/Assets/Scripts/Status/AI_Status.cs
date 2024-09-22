using UnityEngine;

public class AI_Status : Status, IDamageable
{
    [SerializeField] private AIStats stats;
    [SerializeField] private float currentHealth;

    void Awake(){
        currentHealth = stats.GetMaxHealth();
    }

    public void TakeDamage(RaycastHit hit, float damageAmount, GameObject attackOrigin){
        if(canTakeDamage && isAlive){
            Debug.Log($"AI took {damageAmount} points of damage from {attackOrigin}");
            currentHealth -= damageAmount;

            PlayHitSound();

            if(currentHealth <= 0f){
                Die();
            }
        }
    }

    public void TakeDamage(Transform other, float damageAmount, GameObject attackOrigin){
        if (canTakeDamage && isAlive){
            Debug.Log($"AI took {damageAmount} points of damage from {attackOrigin}");
            currentHealth -= damageAmount;
        
            PlayHitSound();
            
            if(currentHealth <= 0f){
                Die();
            }
            // else{
            //     AddIFrames(iFramesInSeconds);
            // }
        }
    }

    public void TakeDamage(Transform other, float damageAmount){
        if(canTakeDamage && isAlive){
            Debug.Log($"AI took {damageAmount} points of damage");
            currentHealth -= damageAmount;

            PlayHitSound();

            if(currentHealth <= 0f){
                Die();
            }
        }
    }
}
