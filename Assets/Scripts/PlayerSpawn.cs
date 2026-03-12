using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static string nextSpawnPoint;

    void Start()
    {
        if (!string.IsNullOrEmpty(nextSpawnPoint))
        {
            GameObject spawn = GameObject.Find(nextSpawnPoint);
            if (spawn != null)
            {
                transform.position = spawn.transform.position;
            }
        }
    }
}