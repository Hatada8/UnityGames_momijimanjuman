using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
    public static string nextSpawnPoint;

    IEnumerator Start()
    {
        // 1フレーム待つ
        yield return null;

        if (!string.IsNullOrEmpty(nextSpawnPoint))
        {
            GameObject spawn = GameObject.Find(nextSpawnPoint);

            if (spawn != null)
            {
                transform.position = spawn.transform.position;
            }
            else
            {
                Debug.LogWarning("SpawnPointが見つかりません: " + nextSpawnPoint);
            }
        }
    }
}