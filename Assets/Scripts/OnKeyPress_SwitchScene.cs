using UnityEngine;
using UnityEngine.SceneManagement;

// Dキーを押すとシーンを切り替える
public class OnKeyPress_SwitchScene : MonoBehaviour
{
    public string sceneName; // Inspectorで指定するシーン名

    // 世界に1つだけの存在を記録する変数
    private static OnKeyPress_SwitchScene instance;

    void Awake()
    {
        // まだ世界に誰もいない場合（最初のシーン）
        if (instance == null)
        {
            instance = this;
            // 💡 シーン移動しても自分自身（GameObject）を消さないようにする
            DontDestroyOnLoad(gameObject);
        }
        // すでに存在している場合（2回目以降のシーン読み込み）
        else
        {
            // 新しく生まれたダブりの方は即座に消去する
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Dキーが押された瞬間
        if (Input.GetKeyDown(KeyCode.D))
        {
            // シーン切り替え
            SceneManager.LoadScene(sceneName);
        }
    }
}