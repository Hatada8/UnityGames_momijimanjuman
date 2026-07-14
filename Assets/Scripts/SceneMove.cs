using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string nextSceneName;

    // 次のシーンで出現する場所
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 次の出現地点を保存
            PlayerSpawn.nextSpawnPoint = spawnPointName;

            // シーン移動
            SceneManager.LoadScene(nextSceneName);
        }
    }
}