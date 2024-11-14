using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/No Ability")]
public class NoAbilityEquipped : AbilitySO
{
    public override void Activate()
    {
        Debug.Log("Nothing Happened");
    }
}
