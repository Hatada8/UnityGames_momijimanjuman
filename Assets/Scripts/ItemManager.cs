using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public Image itemImage;
    public static ItemManager Instance;
    private List<Sprite> ownedItems = new List<Sprite>(); // 所持アイテム
    private int currentIndex = 0;
    private HashSet<string> collectedItemIDs = new HashSet<string>();
    public Sprite momijiManjuSprite; //もみじまんじゅうのスプライト
    public Sprite nonConsumableItem; // 消えないアイテム

    public void MarkItemCollected(string id)
    {
        collectedItemIDs.Add(id);
    }

    public bool IsItemCollected(string id)
    {
        return collectedItemIDs.Contains(id);
    }
    public Sprite GetCurrentItem()
   {
        if (ownedItems.Count == 0) return null;
        return ownedItems[currentIndex];
   }

    public void RemoveCurrentItem()
    {
        if (ownedItems.Count == 0) return;
        Sprite currentItem = ownedItems[currentIndex];

        // 🍁 消えないアイテム判定
        if (currentItem == nonConsumableItem)
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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        ownedItems.Add(momijiManjuSprite);  //もみじまんじゅうを持っている。
        currentIndex = 0;
    }
    void Start()
    {
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


    void Update()
    {
        if (ownedItems.Count > 0 && Input.GetKeyDown(KeyCode.A))
        {
            ChangeItem();
        }
    }

    // 🔹 アイテム取得時に呼ばれる
    public void GetItem(Sprite newItem)
    {
        ownedItems.Add(newItem);
        currentIndex = ownedItems.Count - 1;

        itemImage.sprite = ownedItems[currentIndex];
        itemImage.enabled = true; // 表示
    }

    void ChangeItem()
    {
        currentIndex++;
        if (currentIndex >= ownedItems.Count)
            currentIndex = 0;

        itemImage.sprite = ownedItems[currentIndex];
    }
}