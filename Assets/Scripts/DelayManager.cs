using UnityEngine;

public class DelayManager : MonoBehaviour
{
    public GameObject buttonObject;

    public float appearTime = 90f;

    void Start()
    {
        // 最初は非表示
        buttonObject.SetActive(false);

        // 指定秒後に表示
        Invoke(nameof(ShowButton), appearTime);
    }

    void ShowButton()
    {
        buttonObject.SetActive(true);
    }
}