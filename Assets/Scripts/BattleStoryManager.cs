using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleStoryManager : MonoBehaviour
{
    [System.Serializable]
    public class StoryEvent
    {
        public int triggerHP;

        [TextArea(2, 5)]
        public string[] sentences;
    }

    public TextMeshProUGUI textUI;

    // コメント背景Panel
    public Image panelUI;

    public ObjectsHP hp;

    public StoryEvent[] storyEvents;

    public float messageInterval = 2f;

    bool[] triggered;

    void Start()
    {
        // 最初は非表示
        textUI.gameObject.SetActive(false);
        panelUI.gameObject.SetActive(false);

        triggered = new bool[storyEvents.Length];
    }

    void Update()
    {
        for (int i = 0; i < storyEvents.Length; i++)
        {
            if (!triggered[i] && hp.hp <= storyEvents[i].triggerHP)
            {
                triggered[i] = true;

                StartCoroutine(PlayStory(storyEvents[i].sentences));

                break;
            }
        }
    }

    IEnumerator PlayStory(string[] sentences)
    {
        // 表示
        textUI.gameObject.SetActive(true);
        panelUI.gameObject.SetActive(true);

        foreach (string sentence in sentences)
        {
            textUI.text = sentence;

            yield return new WaitForSeconds(messageInterval);
        }

        // 非表示
        textUI.gameObject.SetActive(false);
        panelUI.gameObject.SetActive(false);
    }
}