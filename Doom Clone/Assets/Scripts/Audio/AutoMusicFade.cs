using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMusicFade : MusicFade
{
    [SerializeField] private float _delayTime = 0f;
    [Tooltip("Overrides Fade Out On Awake, if selected")] [SerializeField] private bool _fadeInOnAwake = false;
    [Tooltip("Overrides Fade Out On Awake, if selected")] [SerializeField] private bool _fadeOutOnAwake = false;
    
    void Start()
    {
        if(_fadeInOnAwake){
            Invoke("FadeIn", _delayTime);
        }
        else if(_fadeOutOnAwake){
            Invoke("FadeOut", _delayTime);
        }
    }
}
