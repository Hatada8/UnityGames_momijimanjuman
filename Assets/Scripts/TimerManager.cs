using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 180f;
    bool timerRunning = true;

    public static TimeManager instance;

    void Awake()
    {
        GameObject rootObject = transform.root.gameObject;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(rootObject);
        }
        else
        {
            Destroy(rootObject);
            return;
        }
    }

    void Update()
    {
        if (!timerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            DisplayTime(timeRemaining);
            
            // 時間切れ判定
            CheckGameResult();
        }
    }

    void CheckGameResult()
    {
        // GiftCountのインスタンスから現在のカウントを取得
        int currentGifts = GiftCount.Instance.giftCount; 

        if (currentGifts >= 10)
        {
            SceneManager.LoadScene("GameClear"); 
        }
        else
        {
            SceneManager.LoadScene("GameOver"); 
        }

        // シーン遷移後、タイマー（Persistentごと）を消したい場合はここで壊す
        // Destroy(transform.root.gameObject); 
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timerText == null) return;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}