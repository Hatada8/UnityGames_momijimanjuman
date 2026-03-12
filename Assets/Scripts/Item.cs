using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemID;  // ← 追加
    public Sprite itemSprite;
    private bool canPickUp = false;

    void Start()
    {
        // すでに取得済みなら消す
        if (ItemManager.Instance.IsItemCollected(itemID))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.A))
        {
            ItemManager.Instance.GetItem(itemSprite);
            ItemManager.Instance.MarkItemCollected(itemID);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canPickUp = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canPickUp = false;
    }
}