using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public Image imageUI;

    public string[] sentences;
    public Sprite[] images;

    public int[] changePoints;

    // 効果音
    public int[] sePoints;
    public AudioClip[] seClips;

    // BGM
    public int[] bgmPoints;
    public AudioClip[] bgmClips;

    // ← Inspectorで設定
    public AudioSource seSource;
    public AudioSource bgmSource;

    public string nextSceneName;
    public float sceneDelay = 1.5f;

    public float firstSlideLockTime = 3f;
    private bool canAdvance = false;

    int currentIndex = 0;
    int currentImageIndex = 0;
    int currentSEIndex = 0;
    int currentBGMIndex = 0;

    void Start()
{
    textUI.text = sentences[0];
    imageUI.sprite = images[0];

    bgmSource.loop = true;

    // =========================
    // 最初のSE
    // =========================
    if (sePoints.Length > 0 &&
        sePoints[0] == 0)
    {
        if (seClips.Length > 0 &&
            seClips[0] != null)
        {
            seSource.PlayOneShot(seClips[0]);
        }

        currentSEIndex = 1;
    }

    // =========================
    // 最初のBGM
    // =========================
    if (bgmPoints.Length > 0 &&
        bgmPoints[0] == 0)
    {
        if (bgmClips.Length > 0 &&
            bgmClips[0] != null)
        {
            bgmSource.clip = bgmClips[0];
            bgmSource.Play();
        }

        currentBGMIndex = 1;
    }
    Invoke(nameof(EnableAdvance), firstSlideLockTime);
}
    
    void EnableAdvance()
    {
        canAdvance = true;
    }
    void Update()
    {
        if (!canAdvance)
            return;
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        currentIndex++;

        if (currentIndex >= sentences.Length)
        {
            Invoke(nameof(LoadNextScene), sceneDelay);
            enabled = false;
            return;
        }

        textUI.text = sentences[currentIndex];

        // 画像変更
        if (currentImageIndex < changePoints.Length &&
            currentIndex == changePoints[currentImageIndex])
        {
            currentImageIndex++;

            if (currentImageIndex < images.Length)
            {
                imageUI.sprite = images[currentImageIndex];
            }
        }

        // 効果音
        if (currentSEIndex < sePoints.Length &&
            currentIndex == sePoints[currentSEIndex])
        {
            if (currentSEIndex < seClips.Length &&
                seClips[currentSEIndex] != null)
            {
                seSource.PlayOneShot(seClips[currentSEIndex]);
            }

            currentSEIndex++;
        }

        // BGM変更
        if (currentBGMIndex < bgmPoints.Length &&
            currentIndex == bgmPoints[currentBGMIndex])
        {
            if (currentBGMIndex < bgmClips.Length &&
                bgmClips[currentBGMIndex] != null)
            {
                bgmSource.Stop();

                bgmSource.clip = bgmClips[currentBGMIndex];
                bgmSource.Play();
            }

            currentBGMIndex++;
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}