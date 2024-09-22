using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    [SerializeField] private float _fadeDuration;

    public void FadeMusicOut(){
        MusicManager.FadeOut(_fadeDuration);
    }
}
