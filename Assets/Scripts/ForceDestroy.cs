using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ForceDestroy : MonoBehaviour
{
    void Start()
    {
        // コルーチンを起動して、安全なタイミングで大掃除を実行する
        StartCoroutine(CleanUpDontDestroyScene());
    }

    IEnumerator CleanUpDontDestroyScene()
    {
        // 1. 一時的なオブジェクトを作ってシーンを取得する
        GameObject temp = new GameObject("Temp");
        DontDestroyOnLoad(temp);
        Scene dontDestroyScene = temp.scene;

        // 2. tempを破棄する
        Destroy(temp);

        // 💡 ここが超重要！
        // tempが完全に消滅し、他のオブジェクトの引っ越しが落ち着くまで1フレーム待つ
        yield return null; 

        // 3. 1フレーム待った後、有効なオブジェクトだけを大掃除する
        if (dontDestroyScene.IsValid())
        {
            foreach (GameObject obj in dontDestroyScene.GetRootGameObjects())
            {
                // すでに消えかかっているもの（tempなど）や、nullのものはスキップ
                if (obj == null) continue;

                // 除外タグのチェック
                if (obj.CompareTag("NoDestroy"))
                    continue;

                // 完全に削除
                Destroy(obj);
            }
        }
    }
}
