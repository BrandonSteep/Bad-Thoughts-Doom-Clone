using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [Header("Points")]
    [SerializeField] private GameEvent score10;
    [SerializeField] private GameEvent score25;
    [SerializeField] private ScriptableVariable totalScore;
    [SerializeField] private ScriptableVariable highScore;
    [SerializeField] private bool bonusPoints = false;
    private bool _canTakeDamage = true;

    [Header("Effects")]
    [SerializeField] private GameObject brokenTarget;
    private ParticleSystem particles;

    void OnEnable(){
        particles = GetComponentInChildren<ParticleSystem>();
    }

    public void TakeDamage(RaycastHit hit, float damageAmount){
        if(_canTakeDamage){
            _canTakeDamage = false;
            GetComponent<Collider>().enabled = false;
            Die();
        }
    }

    public void Die(){
        GameObject broken = Instantiate(brokenTarget, this.transform);
        broken.transform.SetParent(null);
        Destroy(this.gameObject);
    }

    private void IncreaseScore(){
        if(bonusPoints){
            score25.Raise();
        }
        else score10.Raise();
    }

    public void Despawn(){
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;

        particles.Play();

        Destroy(this.gameObject, 2f);
    }
}
