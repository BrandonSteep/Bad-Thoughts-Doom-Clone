using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/~Currently Active~")]
public class CurrentlyActiveAbility : ScriptableObject
{
    public AbilitySO _activeAbility;
}
