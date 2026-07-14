using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartHP : MonoBehaviour
{
    [Header("HP設定")]
    public int hp = 3; // 現在HP（ハート3つ）
    public string damageTag = "Ballet"; // 当たった相手のタグ

    [Header("ハートUI")]
    public Image[] hearts; // Heart1, Heart2, Heart3 を入れる
    public Sprite fullHeart; // 赤いハート
    public Sprite emptyHeart; // 空のハート（灰色）

    [Header("シーン遷移")]
    public string sceneNameLose; // 負けシーン
    public string sceneNameWin;  // 勝ちシーン

    [Header("判定用")]
    public string objectType; // "image" or "hiyoko"

    void Start()
    {
        UpdateHearts();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 指定タグに当たったらダメージ
        if (collision.CompareTag(damageTag))
        {
            hp--;

            Debug.Log(gameObject.name + " のHP : " + hp);

            // 当たった相手を消す
            Destroy(collision.gameObject);

            // ハート更新
            UpdateHearts();

            // HP0でシーン遷移
            if (hp <= 0)
            {
                // image → 負け
                if (objectType == "image")
                {
                    SceneManager.LoadScene(sceneNameLose);
                }

                // hiyoko → 勝ち
                if (objectType == "hiyoko")
                {
                    SceneManager.LoadScene(sceneNameWin);
                }
            }
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}