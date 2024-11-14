using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene Controller")]
public class SceneControllerSO : ScriptableObject
{
    [SerializeField] private string _sceneName;
    private Transform _playerSpawnTransform;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadScene(string name)
    {
        LoadScene(name);
    }

    public void SpawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No player object found in scene");
            return;
        }

        player.transform.position = _playerSpawnTransform.position;
        player.transform.rotation = _playerSpawnTransform.rotation;
    }

    public void SetPlayerSpawnTransform(Transform playerSpawnTransform){
        if (playerSpawnTransform == null)
        {
            Debug.LogError("No player spawn transform set - Defaulting to 0,0,0");
            _playerSpawnTransform.position = Vector3.zero;
            _playerSpawnTransform.rotation = Quaternion.identity;
        }
        else{
            _playerSpawnTransform = playerSpawnTransform;
        }
    }
}