using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public AbilitySO _equippedAbility;
    [SerializeField] private CurrentlyActiveAbility _activeAbility;
    public AbilitySO _newAbility;

    [SerializeField] private ScriptableVariable _cooldownTimer;
    [SerializeField] private GameEvent _abilityReady;
    [SerializeField] private GameEvent _abilitySwapped;

    [SerializeField] private AudioSource _aSource;
    [SerializeField] private AudioClip _rechargedSFX;
    
    public bool _isReady;

    public void EquipAbility(){
        if(_newAbility != null && _newAbility != _equippedAbility){
            _equippedAbility = _newAbility;
        }
        _isReady = true;
        _activeAbility._activeAbility = _equippedAbility;
        _abilitySwapped.Raise();
        Debug.Log("Ability Equipped");
    }

    void Update(){
        if(_equippedAbility._cooldownTimer != null){
            if(_cooldownTimer.value < _equippedAbility._cooldownTimer.value){
                _cooldownTimer.value += Time.deltaTime;
            }
            else if(!_isReady){
                _isReady = true;
                _aSource.PlayOneShot(_rechargedSFX);
                _abilityReady.Raise();
            }
        }
    }

    void FixedUpdate(){
        if(_equippedAbility._triggerOnUpdate){
            _equippedAbility.RunScript();
        }
    }

    public void Activate(){
        if(_isReady){
            Debug.Log("Activating Ability");
            _isReady = false;
            _equippedAbility.Activate();
            _cooldownTimer.value = 0f;

            _aSource.PlayOneShot(_equippedAbility._activateSFX);
            // StartCoroutine("Cooldown");
        }
    }

    // private IEnumerator Cooldown(){
    //     yield return new WaitForSeconds(_equippedAbility._cooldownTimer);
    //     _isReady = true;
    //     yield return null;
    // }

    void OnEnable(){
        _aSource = GetComponent<AudioSource>();
        EquipAbility();
    }
}
