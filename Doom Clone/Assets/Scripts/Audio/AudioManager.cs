using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private static List<AudioSource> sources = new List<AudioSource>();
    private static int currentIndex = 0;

    void OnEnable()
    {
        if(instance == null){        
            instance = this;
        }
        else{
            Destroy(this.gameObject);
        }
        foreach(AudioSource source in this.transform.GetComponents<AudioSource>()){
            sources.Add(source);
        }
        Debug.Log(sources);
    }

    public static void PlayOneShot(AudioClip clip){
        if(currentIndex !< sources.Count){
            currentIndex = 0;
        }
        Debug.Log($"Playing {clip} at {sources[currentIndex].name}");
        
        sources[currentIndex].PlayOneShot(clip, Random.Range(0.95f, 1.05f));
        currentIndex++;
    }
}
