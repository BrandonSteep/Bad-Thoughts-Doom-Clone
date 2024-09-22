using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    private bool gamePaused = false;

    public void PauseGame(){
        if(!gamePaused){
            Time.timeScale = 0f;
            gamePaused = true;
        }
        else{
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }
}
