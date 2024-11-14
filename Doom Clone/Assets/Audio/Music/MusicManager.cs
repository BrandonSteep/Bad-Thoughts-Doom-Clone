using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private AudioClip _currentTrack;
    [SerializeField] private AudioClip _nextTrack;
    private static AudioSource _aSource;
    
    [SerializeField] private float _defaultFadeLength = 2f;
    [SerializeField] private static float _musicVolume = 1f;

    void Awake(){
        if(instance != null && instance != this){
            Debug.Log("Multiple Music Managers found - Destroying this one");
            Destroy(this.gameObject);
        }
        else{
            instance = this;

            _aSource = GetComponent<AudioSource>();
            FadeIn();
        }
    }

    public static void ChangeTrack(AudioClip newTrack, float fadeDuration){
        instance._nextTrack = newTrack;
        instance.FadeIn(fadeDuration);
    }

    private void FadeIn(){
        _aSource.volume = 0f;
        _currentTrack = _nextTrack;
        StartMusic();
        StartCoroutine(Fade(_defaultFadeLength, _musicVolume));
    }

    public void FadeOut(){
        StartCoroutine(Fade(_defaultFadeLength, _musicVolume));
        Invoke("StopMusic", _defaultFadeLength);
    }

    private void FadeIn(float duration){
        _aSource.volume = 0f;
        _currentTrack = _nextTrack;
        StartMusic();
        StartCoroutine(Fade(duration, _musicVolume));
    }

    public static void FadeOut(float duration){
        instance.StartCoroutine(instance.Fade(duration, _musicVolume));
        // Invoke("StopMusic", duration);
    }

    public IEnumerator Fade(float duration, float targetVolume){
        float time = 0f;
        float startVol = _aSource.volume;
        while(time < duration){
            time += Time.deltaTime;
            _aSource.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }
    }

    private void StartMusic(){
        Debug.Log("Starting Music");
        _aSource.clip = _currentTrack;
        _aSource.Play();
    }

    private void StopMusic(){
        Debug.Log("Stopping Music");
        _aSource.Stop();
    }
}
