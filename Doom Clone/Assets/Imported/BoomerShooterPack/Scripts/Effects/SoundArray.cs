using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundArray : MonoBehaviour
{
    [SerializeField] private bool _canPlay = true;
    [SerializeField] private AudioClip[] _sounds;

    private int _soundsLength;
    private AudioSource _source;

    void OnEnable(){
        _source = GetComponent<AudioSource>();
        if(_source==null){
            _source = this.gameObject.AddComponent<AudioSource>();
        }
        _soundsLength = _sounds.Length;
    }

    public void PlaySound(int i){
        if(_canPlay){
            _source.pitch = Random.Range(0.95f, 1.05f);
            _source.PlayOneShot(_sounds[i]);
        }
    }

    public virtual void PlayRandom(){
        if(_canPlay){
            _source.pitch = Random.Range(0.95f, 1.05f);
            _source.PlayOneShot(_sounds[Random.Range(0, _soundsLength)]);
        }
    }

    public void EnableSoundArray(bool active){
        _canPlay = active;
    }
}
