using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private float healthToAdd = 25f;
    [SerializeField] private float collectLimit = 100f;
    [SerializeField] private GameEvent collectEvent;

    private void OnTriggerEnter(Collider other){
        Debug.Log("Triggered lol");
        if(other.tag == "Player" && ControllerReferences.playerStatus.currentHp.value < collectLimit){
            PickUp();
        }
    }

    public void PickUp(){
        float remainder = collectLimit - ControllerReferences.playerStatus.currentHp.value;
        if(remainder < healthToAdd){
            Debug.Log($"Medkawit Picked Up - Adding {remainder} to Player HP");
            ControllerReferences.playerStatus.AddHealth(remainder);
        }
        else{
            Debug.Log($"Medkit Picked Up - Adding {healthToAdd} to Player HP");
            ControllerReferences.playerStatus.currentHp.value += healthToAdd;
        }
        collectEvent.Raise();
        Destroy(this.gameObject);
    }
}
