using UnityEngine;

public class NPCItemSpawner : MonoBehaviour
{
    public string npcID;

    public Sprite requiredItem;

    public int requiredAmount = 1;

    public GameObject itemToSpawn;

    private bool spawned = false;

    void Start()
    {
        int count = ItemManager.Instance.GetGivenAmount(npcID);

        if (count >= requiredAmount)
        {
            spawned = true;

            if (itemToSpawn != null)
            {
                itemToSpawn.SetActive(true);
            }
        }
        else
        {
            if (itemToSpawn != null)
            {
                itemToSpawn.SetActive(false);
            }
        }
    }

    public void ReceiveItem()
    {
        if (spawned) return;

        ItemManager.Instance.AddGivenAmount(npcID);

        int count = ItemManager.Instance.GetGivenAmount(npcID);

        Debug.Log(npcID + " : " + count);

        if (count >= requiredAmount)
        {
            itemToSpawn.SetActive(true);

            spawned = true;
        }
    }
}