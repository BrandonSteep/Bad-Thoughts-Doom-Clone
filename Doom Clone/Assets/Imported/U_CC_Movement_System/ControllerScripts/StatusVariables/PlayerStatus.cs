using UnityEngine;

public class PlayerStatus : Status, IDamageable
{
    [SerializeField] public ScriptableVariable currentHp;
    [SerializeField] public ScriptableVariable maxHp;
    
    [SerializeField] private ScriptableVariable currentArmour;
    [SerializeField] private ScriptableVariable maxArmour;

    [SerializeField] private float iFramesInSeconds;
    [SerializeField] private float knockbackForce;
    
    void Awake(){
        currentHp.value = maxHp.value;
        currentArmour.value = maxArmour.value;
    }

    #region Damage Calculation
    public void TakeDamage(RaycastHit hit, float damageAmount, GameObject attackOrigin){
        if (canTakeDamage && isAlive){
            float damageToDeal = DamageWithArmourAdjustments(damageAmount);
            currentHp.value -= damageToDeal;
            ControllerReferences.playerAnim.SetTrigger("TakeDamage");
            ControllerReferences.playerKnockback.AddImpact(transform.position - attackOrigin.transform.position, knockbackForce);
            if(currentHp.value <= 0f){
                Die();
            }
            else{
                AddIFrames(iFramesInSeconds);
            }
        }
    }

    public void TakeDamage(Transform other, float damageAmount, GameObject attackOrigin){
        Debug.LogWarning($"Player hit with projectile from {attackOrigin}, dealing {damageAmount} damage");
        if (canTakeDamage && isAlive){
            float damageToDeal = DamageWithArmourAdjustments(damageAmount);
            currentHp.value -= damageToDeal;

            ControllerReferences.playerAnim.SetTrigger("TakeDamage");
            ControllerReferences.playerKnockback.AddImpact(attackOrigin.transform, knockbackForce);
            if(currentHp.value <= 0f){
                Die();
            }
            else{
                AddIFrames(iFramesInSeconds);
            }
        }
    }

    private float DamageWithArmourAdjustments(float damageAmount){
        float newDamage;
        if(currentArmour.value >= 100f){
            newDamage = damageAmount * 0.5f;
            float armourDamage = damageAmount * 0.5f;
            newDamage += CalculateRemainder(armourDamage);
        }
        else if(currentArmour.value < 100f && currentArmour.value != 0f){
            newDamage = damageAmount * 0.666666f;
            float armourDamage = damageAmount * 0.333333f;
            newDamage += CalculateRemainder(armourDamage);
        }
        else{
            Debug.Log("No Armour Damage Taken");
            newDamage = damageAmount;
        }

        return newDamage;
    }

    private float CalculateRemainder(float armourDamage){
        if (currentArmour.value >= armourDamage){
            Debug.Log($"Removing {armourDamage} points of Armour");
            currentArmour.value -= armourDamage;
            return 0f;
        }
        else{
            currentArmour.value = 0f;
            return armourDamage - currentArmour.value;
        }
    }
    
    protected override void Die(){
        // PLAY DEATH FX
        Debug.Log("YOU R DED");
        base.Die();
    }

#endregion

    #region Health & Armour Pickups

    public void AddHealth(float amount){
        currentHp.value += amount;
    }

    public void PickupSuperHealth(){
        if(currentHp.value < 200f){
            currentHp.value = 200f;
        }
    }

    public void PickupMedkit(){
        float remainder = maxHp.value - currentHp.value;
        if(remainder < 25f){
            currentHp.value += remainder;
        }
        else{
            currentHp.value += 25f;
        }
    }

    public void PickupStim(){
        float remainder = maxHp.value - currentHp.value;
        if(remainder < 10f){
            currentHp.value += remainder;
        }
        else{
            currentHp.value += 10f;
        }
    }

    public void PickupHealthBonus(){
        if(currentHp.value < 200f){
            currentHp.value += 1f;
        }
    }
    
    public void PickupSuperAmour(){
        if(currentArmour.value < 200f){
            currentArmour.value = 200f;
        }
    }

    public void PickupFullAmour(){
        if(currentArmour.value < 100f){
            currentArmour.value = 100f;
        }
    }

    public void PickupSmallArmour(){
        float remainder = maxArmour.value - currentArmour.value;
        if(remainder < 25f){
            currentArmour.value += remainder;
        }
        else{
            currentArmour.value += 10f;
        }
    }

    public void PickupArmourBonus(){
        if(currentArmour.value < 200f){
            currentArmour.value += 1f;
        }
    }

#endregion

    #region Return Functions

    public float GetMaxHealth(){
        return maxHp.value;
    }

#endregion
}
