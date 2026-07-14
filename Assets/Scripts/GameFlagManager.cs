using UnityEngine;

public class GameFlagManager : MonoBehaviour
{
    public static GameFlagManager Instance;

    private bool talkedToMomotaro = false;

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

    public void SetTalkedToMomotaro()
    {
        talkedToMomotaro = true;
    }

    public bool HasTalkedToMomotaro()
    {
        return talkedToMomotaro;
    }
}