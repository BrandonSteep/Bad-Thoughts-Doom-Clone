using UnityEngine;
using UnityEngine.UI;

public class AbilitySO : ScriptableObject
{
    public ScriptableVariable _cooldownTimer;
    public Sprite _spriteImage;
    public bool _triggerOnUpdate = false;

    public AudioClip _activateSFX;

    public virtual void Initialise(){}
    public virtual void Disable(){}
    public virtual void Activate(){}
    public virtual void RunScript(){}
}
