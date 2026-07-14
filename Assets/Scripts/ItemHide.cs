using UnityEngine;

public class ItemHide : MonoBehaviour
{
    public string itemID;
    public Sprite itemSprite;

    private bool canPickUp = false;
    private bool alreadyPicked = false; // ← 追加

    void Start()
    {
        // すでに取得済みなら取れない状態にする
        if (ItemManager.Instance.IsItemCollected(itemID))
        {
            alreadyPicked = true;
        }
    }

    void Update()
    {
        if (canPickUp && !alreadyPicked && Input.GetKeyDown(KeyCode.A))
        {
            ItemManager.Instance.GetItem(itemSprite);
            ItemManager.Instance.MarkItemCollected(itemID);

            alreadyPicked = true; // ← もう取れないようにする
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