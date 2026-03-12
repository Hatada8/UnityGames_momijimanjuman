using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMove : MonoBehaviour
{
    public string nextSceneName;
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSpawn.nextSpawnPoint = spawnPointName;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}