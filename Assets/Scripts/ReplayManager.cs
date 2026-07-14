using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public static ReplayManager Instance;

    public bool movedBattleScene = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}