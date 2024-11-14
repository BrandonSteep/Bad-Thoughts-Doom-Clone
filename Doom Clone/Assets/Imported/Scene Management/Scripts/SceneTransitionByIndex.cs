using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionByIndex : MonoBehaviour
{
    [SerializeField] private intSO _sceneIndex;
    [SerializeField] private Transform _playerSpawnTransform;

    private bool _canTransition = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canTransition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canTransition = false;
        }
    }

    public void TriggerTransitionAfterTime(float time){
        Invoke("TriggerTransition", time);
    }

    public void TriggerTransition(){
        _canTransition = true;
    }

    private void Update()
    {
        if (_canTransition)
        {
            SceneManager.LoadScene(_sceneIndex.value);
        }
    }
}