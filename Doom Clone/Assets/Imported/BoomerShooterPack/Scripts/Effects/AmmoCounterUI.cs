using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private ScriptableVariable count;
    
    void Update(){
        text.text = count.value.ToString("00");
    }
}
