using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectsHP : MonoBehaviour
{
    public int maxHP = 100;
    public int hp = 100;

    public Image hpBar; // UIのImage

    public string sceneNameLose;
    public string sceneNameWin;

    public string damageTag = "Ballet";
    public string objectType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(damageTag))
        {
            hp -= 1;

            // HPバー更新
            hpBar.fillAmount = (float)hp / maxHP;

            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                if (objectType == "image")
                {
                    SceneManager.LoadScene(sceneNameLose);
                }

                if (objectType == "hiyoko")
                {
                    SceneManager.LoadScene(sceneNameWin);
                }
            }
        }
    }
}