using UnityEngine;
using TMPro;

public class DisplayNumbers : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private ScriptableVariable floatToDisplay;
    private float currentValue;

    void Awake(){
        if(!textBox){
            textBox = GetComponent<TMP_Text>();
        }
        currentValue = floatToDisplay.value;
    }

    void Update(){
        if(currentValue != floatToDisplay.value){
            currentValue = floatToDisplay.value;
            textBox.text = currentValue.ToString("F0");
        }
    }
}
