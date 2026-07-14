using UnityEngine;
using UnityEngine.UI;

public class DelayedManager : MonoBehaviour
{
    public float appearTime = 90f;

    Button button;
    Image image;

    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        // 最初は押せない
        button.interactable = false;

        // 透明化
        Color c = image.color;
        c.a = 0;
        image.color = c;

        Invoke(nameof(ShowButton), appearTime);
    }

    void ShowButton()
    {
        // 表示
        Color c = image.color;
        c.a = 1;
        image.color = c;

        // 押せるようにする
        button.interactable = true;
    }
}