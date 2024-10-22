using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private SceneControllerSO _sceneController;
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
            if (_playerSpawnTransform != null){
                Debug.Log($"Setting Next Position as {_playerSpawnTransform.localPosition}");
                
                // Save Position to PlayerPrefs //
                PlayerPrefs.SetFloat("NextPositionX", _playerSpawnTransform.localPosition.x);
                PlayerPrefs.SetFloat("NextPositionY", _playerSpawnTransform.localPosition.y);
                PlayerPrefs.SetFloat("NextPositionZ", _playerSpawnTransform.localPosition.z);

                // Save Rotation to PlayerPrefs //
                PlayerPrefs.SetFloat("NextRotationX", _playerSpawnTransform.localRotation.x);
                PlayerPrefs.SetFloat("NextRotationY", _playerSpawnTransform.localRotation.y);
                PlayerPrefs.SetFloat("NextRotationZ", _playerSpawnTransform.localRotation.z);
                PlayerPrefs.SetFloat("NextRotationW", _playerSpawnTransform.localRotation.w);
            }

            _sceneController.LoadScene();
        }
    }
}