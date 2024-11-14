using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private GameEvent eventToCall;
    [SerializeField] private bool canBePressed = true;
    [SerializeField] private bool isRepeatable = false;

    [SerializeField] private AudioClip pressSound;

    public void Interact(){
        if(canBePressed){
            eventToCall.Raise();
            AudioManager.PlayOneShot(pressSound);
            if(!isRepeatable){
                SetButtonPressableFalse();
            }
        }
    }

    public void SetButtonPressableFalse(){
        canBePressed = false;
    }
    public void SetButtonPressableTrue(){
        canBePressed = false;
    }
}
