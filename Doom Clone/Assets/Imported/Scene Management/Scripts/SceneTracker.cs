using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    [SerializeField] private intSO sceneIndex;

    void OnEnable(){
        sceneIndex.value = SceneManager.GetActiveScene().buildIndex;
    }
}
