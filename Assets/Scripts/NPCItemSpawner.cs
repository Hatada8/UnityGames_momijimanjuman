using UnityEngine;

public class NPCItemSpawner : MonoBehaviour
{
    public Sprite requiredItem;     // 必要アイテム
    public int requiredAmount = 1;  // 必要個数（Inspectorで調整）

    public GameObject itemToSpawn;  // 出現させるアイテム

    private int givenAmount = 0;
    private bool spawned = false;

    void Start()
    {
        if (itemToSpawn != null)
        {
            itemToSpawn.SetActive(false);
        }
    }

    void Update()
    {
        if (spawned) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            TryGiveItem();
        }
    }

    void TryGiveItem()
    {
        Sprite currentItem = ItemManager.Instance.GetCurrentItem();

        if (currentItem == requiredItem)
        {
            ItemManager.Instance.RemoveCurrentItem();
            givenAmount++;

            if (givenAmount >= requiredAmount)
            {
                SpawnItem();
            }
        }
    }

    void SpawnItem()
    {
        if (itemToSpawn != null)
        {
            itemToSpawn.SetActive(true);
        }

        spawned = true;
    }
}