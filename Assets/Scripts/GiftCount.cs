using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // Listを使うために追加

public class GiftCount : MonoBehaviour
{
    public static GiftCount Instance;
    public TextMeshProUGUI giftCountText;

    public int giftCount = 0;
    private List<string> givenNPCNames = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject); 
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 新しいシーンでTextを探す
        giftCountText = GameObject.Find("GiftCountText")
            ?.GetComponent<TextMeshProUGUI>();

        UpdateUI();
    }

    public void AddGiftCount(string npcName)
    {
        if (HasGivenTo(npcName)) return;
        
        givenNPCNames.Add(npcName);
        giftCount++;
        UpdateUI();
    }
    
    public bool HasGivenTo(string npcName)
    {
        return givenNPCNames.Contains(npcName);
    }

    void UpdateUI()
    {
        giftCountText.text = "渡した人数：" + giftCount + "人";
        
    }
}