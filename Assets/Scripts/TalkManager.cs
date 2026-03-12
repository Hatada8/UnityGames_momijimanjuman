using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public GameObject messageWindow;
    public TextMeshProUGUI uiText;
    public Sprite requiredItem;
    public Sprite requiredItem2;        // 2つ目の要求アイテム
    public GameObject giftPanel;     // 専用パネル
    public GameObject giftPanel2;       // 2つ目のUIパネル
    public TextMeshProUGUI giftText; // 表示するテキスト
    public TextMeshProUGUI giftText2;   // 2つ目のテキスト

    
    [TextArea(3, 10)] 
    public string[] sentences; // セリフのリスト
    [TextArea(2,5)]
    public string[] giftMessages;//あげたときの台詞のリスト
    [TextArea(2,5)]
    public string[] giftMessages2;      // 2つ目のセリフ
    
    private bool itemGiven = false;
    private bool item2Given = false;
    private int currentSentenceIndex = 0; // 今何番目のセリフか
    private int giftIndex = 0;
    private int giftIndex2 = 0;
    private bool isPlayerNearby = false;
    private bool isGiftTalking = false;
    private bool isGiftTalking2 = false;
    private Coroutine typingCoroutine;
    public float typingSpeed = 0.03f; // 1文字の表示速度
    private bool isTalking = false; // 会話中かどうかのフラグ

    // プレイヤーの移動スクリプト（名前は自分のプロジェクトに合わせてください）
    // 例: PlayerMovement という名前の場合
     public MonoBehaviour playerMovement; 

    void Update()
    {
        //giftUIが出ているときspaceを押すと次の会話へいける
        if (!isPlayerNearby) return;
        // 🎁 Gift会話中
        if (isGiftTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DisplayNextGiftSentence();
            }
            return;
        }
        if (isGiftTalking2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DisplayNextGiftSentence2();
            }
            return;
        }

        if(giftPanel != null  && giftPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                giftPanel.SetActive(false);
                EndDialogue();
            }
            return;
        }
        //会話を表示
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTalking)
                StartDialogue();
            else
                DisplayNextSentence();
        }

    // 🍁 W → アイテムを渡す
        if (Input.GetKeyDown(KeyCode.W))
        {
            TryGiveItem();
        }
    }
    void Start()
    {
        if (messageWindow == null)
    {
        messageWindow = GameObject.Find("Panel");
    }

    if (giftPanel == null)
    {
        giftPanel = GameObject.Find("Panel_Gift");
    }

    if (uiText == null)
    {
        uiText = GameObject.Find("MessageText")
            .GetComponent<TextMeshProUGUI>();
    }

    if (giftText == null)
    {
        giftText = GameObject.Find("GiftText")
            .GetComponent<TextMeshProUGUI>();
    }
    if (GiftCount.Instance != null && GiftCount.Instance.HasGivenTo(gameObject.name))
    {
        itemGiven = true;
    }
    }

    void TryGiveItem()
    {
        if (itemGiven) return;

        Sprite currentItem = ItemManager.Instance.GetCurrentItem();

        if (!itemGiven && currentItem == requiredItem)
        {
            ItemManager.Instance.RemoveCurrentItem();
            itemGiven = true;

            GiftCount.Instance.AddGiftCount(gameObject.name);

            ShowGiftUI();
            return;
        }
        // 2つ目のアイテム
        if (!item2Given && currentItem == requiredItem2)
        {
            ItemManager.Instance.RemoveCurrentItem();
            item2Given = true;

            ShowGiftUI2();
        }
    }

    void StartDialogue()
    {
        isTalking = true;

        if (playerMovement != null)
            playerMovement.enabled = false;

    // 🎁 渡した後はGiftMessageを表示
        if (itemGiven)
        {
            ShowGiftUI();
            return;
        }
        
        currentSentenceIndex = 0;
        messageWindow.SetActive(true);
        DisplayNextSentence();
    }

    void ShowGiftUI()
    {
        messageWindow.SetActive(false);  // 通常会話は隠す
        giftPanel.SetActive(true);

        giftIndex=0;
        isGiftTalking=true;
        
        DisplayNextGiftSentence();
    }
    void ShowGiftUI2()
    {
        messageWindow.SetActive(false);
        giftPanel2.SetActive(true);

        giftIndex2 = 0;
        isGiftTalking2 = true;

        DisplayNextGiftSentence2();
    }

    void DisplayNextSentence()
    {
        // 全てのセリフを読み終えたら
        if (currentSentenceIndex >= sentences.Length)
        {
            EndDialogue();
            return;
        }
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
        currentSentenceIndex++;
        
    }
    void DisplayNextGiftSentence2()
{
    if (giftIndex2 >= giftMessages2.Length)
    {
        EndGiftDialogue2();
        return;
    }

    if (typingCoroutine != null)
        StopCoroutine(typingCoroutine);

    typingCoroutine = StartCoroutine(TypeGiftSentence2(giftMessages2[giftIndex2]));
    giftIndex2++;
}
    void DisplayNextGiftSentence()
    {
        if (giftIndex >= giftMessages.Length)
        {
            EndGiftDialogue();
            return;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeGiftSentence(giftMessages[giftIndex]));
        giftIndex++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        uiText.text = "";

        foreach (char letter in sentence)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    IEnumerator TypeGiftSentence(string sentence)
    {
        giftText.text = "";

        foreach (char letter in sentence)
        {
            giftText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    IEnumerator TypeGiftSentence2(string sentence)
{
    giftText2.text = "";

    foreach (char letter in sentence)
    {
        giftText2.text += letter;
        yield return new WaitForSeconds(typingSpeed);
    }
}
    void EndDialogue()
    {
        isTalking = false;
        if (messageWindow != null) 
        {
            messageWindow.SetActive(false);
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
        // プレイヤーの移動スクリプトを戻す処理
        // 【重要】ここでプレイヤーの動きを再開させる
        //GameObject.FindWithTag("Player").GetComponent<YourMoveScript>().enabled = true;
    }
    void EndGiftDialogue()
    {
        isGiftTalking = false;
        giftPanel.SetActive(false);
        EndDialogue();
    }
    void EndGiftDialogue2()
{
    isGiftTalking2 = false;
    giftPanel2.SetActive(false);
    EndDialogue();
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            EndDialogue();
        }
    }
}