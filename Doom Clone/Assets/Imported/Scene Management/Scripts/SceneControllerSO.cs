using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene Controller")]
public class SceneControllerSO : ScriptableObject
{
    [SerializeField] private string[] _sceneNames;
    private Transform _playerSpawnTransform;

    public void LoadScene(int index)
    {
        if (index < 0 || index >= _sceneNames.Length)
        {
            Debug.LogError($"Invalid scene index: {index}");
            return;
        }

        SceneManager.LoadScene(_sceneNames[index]);
    }

    public void LoadScene(string name)
    {
        int index = System.Array.IndexOf(_sceneNames, name);

        if (index < 0)
        {
            Debug.LogError($"Scene name '{name}' not found in list of scene names");
            return;
        }

        LoadScene(index);
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