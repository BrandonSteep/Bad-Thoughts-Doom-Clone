using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicTrack : MonoBehaviour
{
    [SerializeField] private AudioClip _newTrack;
    [SerializeField] private float _fadeDuration;
    
    public void ChangeTrack(){
        Debug.Log($"Changin Music Track to {_newTrack}");
        MusicManager.ChangeTrack(_newTrack, _fadeDuration);
    }
}
