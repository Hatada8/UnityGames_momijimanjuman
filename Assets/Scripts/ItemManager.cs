using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using TMPro;
using System.Collections;
public class ItemManager : MonoBehaviour {
    public GameObject itemGetPanel;
    public TMP_Text itemGetText;
    public float panelDisplayTime = 2f;
    public Image itemImage;
    public static ItemManager Instance;
    private List<Sprite> ownedItems = new List<Sprite>(); 
    // 所持アイテム 
    private int currentIndex = 0;
    private HashSet<string> collectedItemIDs = new HashSet<string>();
    private Dictionary<string, int> npcGivenAmounts = new Dictionary<string, int>();
    public Sprite momijiManjuSprite;
    //もみじまんじゅうのスプライト 
    public Sprite nonConsumableItem;
    // 消えないアイテム 
    public void MarkItemCollected(string id) {
        collectedItemIDs.Add(id); 
    }
    public bool IsItemCollected(string id) {
        return collectedItemIDs.Contains(id);
    }
    public Sprite GetCurrentItem() {
        if (ownedItems.Count == 0)
            return null;
        return ownedItems[currentIndex];
    }
    public void RemoveCurrentItem(NPCItemSpawner spawner)
{
    if (ownedItems.Count == 0)
        return;

    Sprite currentItem = ownedItems[currentIndex];

    if (currentItem == nonConsumableItem)
    {
        return;
    }

    // requiredItem または requiredItem2
    TalkManager talk = spawner.GetComponent<TalkManager>();

    if (spawner != null &&
        (
            currentItem == spawner.requiredItem ||
            currentItem == talk.requiredItem2
        ))
    {
        spawner.ReceiveItem();
    }
    else
    {
        return;
    }

    ownedItems.RemoveAt(currentIndex);

    if (ownedItems.Count == 0)
    {
        itemImage.enabled = false;
        return;
    }

    if (currentIndex >= ownedItems.Count)
        currentIndex = 0;

    itemImage.sprite = ownedItems[currentIndex];
}
   void Awake()
{
    // 世界に1つだけの登録チェック
    if (Instance == null)
    {
        Instance = this;

        // 💡 ここで自分自身をシーン移動で消えないようにする！
        DontDestroyOnLoad(gameObject);

        // アイテムの初期化
        ownedItems.Add(momijiManjuSprite);
        currentIndex = 0;
        
        Debug.Log("ItemManager: 最初の1つ目を正常に保護しました。");
    }
    else
    {
        // 💡 すでに1つ目がある状態（Muraに戻ってきた時など）は、新しい方を即座に消す！
        Debug.Log("ItemManager: ダブりを発見したため、新しい方を削除します。");
        Destroy(gameObject);
        return;
    }
}
    void Start() 
    { 
        Debug.Log("ItemManager Start: itemImage = " + itemImage);
        if (itemImage == null)
        {
            Debug.LogError("itemImage が null です！参照切れの可能性");
            itemImage = GameObject.Find("ItemImage").GetComponent<Image>();
            return;
        }
        if (ownedItems.Count > 0)
        {
            itemImage.sprite = ownedItems[currentIndex];
            itemImage.enabled = true;
        }
        else
        {
            itemImage.enabled = false;
        }
    }
    void Update() {
        if (ownedItems.Count > 0 && Input.GetKeyDown(KeyCode.A))
        {
            ChangeItem();
        }
    } 
    // アイテム取得時に呼ばれる
    public void GetItem(Sprite newItem) 
    { 
        ownedItems.Add(newItem);
        currentIndex = ownedItems.Count - 1;
        itemImage.sprite = ownedItems[currentIndex];
        itemImage.enabled = true;
        // 表示
        // パネル表示
        StartCoroutine(ShowItemGetPanel(newItem.name));
    }
    void ChangeItem() {
         currentIndex++;
         if (currentIndex >= ownedItems.Count)
         currentIndex = 0;
         itemImage.sprite = ownedItems[currentIndex];
        }
    public void AddGivenAmount(string npcID)
    {
    if (!npcGivenAmounts.ContainsKey(npcID))
    {
        npcGivenAmounts[npcID] = 0;
    }

    npcGivenAmounts[npcID]++;
    }
    public int GetGivenAmount(string npcID)
    {
    if (!npcGivenAmounts.ContainsKey(npcID))
    {
        return 0;
    }

    return npcGivenAmounts[npcID];
    }
    IEnumerator ShowItemGetPanel(string itemName)
{
    itemGetPanel.SetActive(true);

    itemGetText.text = itemName + " を手に入れた！";

    yield return new WaitForSeconds(panelDisplayTime);

    itemGetPanel.SetActive(false);
}
}