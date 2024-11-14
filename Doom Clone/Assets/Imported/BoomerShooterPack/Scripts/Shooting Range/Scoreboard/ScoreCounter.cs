using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private ScriptableVariable score;
    [SerializeField] private ScriptableVariable highScore;

    public void IncreaseScoreBy10(){
        score.value += 10;
        UpdateHighScore();
    }

    public void IncreaseScoreBy25(){
        score.value += 25;
        UpdateHighScore();
    }

    private void UpdateHighScore(){
        if(score.value > highScore.value){
            highScore.value = score.value;
        }
    }
}