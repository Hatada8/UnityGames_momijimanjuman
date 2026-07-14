using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 💡 自分自身が消滅したときは、記憶をリセットする
    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}