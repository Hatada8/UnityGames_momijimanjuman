using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;

    void Awake()
    {
        // シングルトン化（1つだけ残す）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン移動しても残る
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // シーン移動
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // リスタート
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 終了（ビルド時のみ）
    public void QuitGame()
    {
        Application.Quit();
    }
}