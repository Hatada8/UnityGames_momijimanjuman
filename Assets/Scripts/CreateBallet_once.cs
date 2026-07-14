using UnityEngine;

public class CreateBallet_once : MonoBehaviour
{
    public GameObject mentaikoPrefab;

    private bool hasShot = false;

    private ObjectsHP objectsHP;

    void Start()
    {
        // 同じオブジェクトについてるObjectsHP取得
        objectsHP = GetComponent<ObjectsHP>();
    }

    void Update()
    {
        // ObjectsHP側のhpを見る
        if (objectsHP.hp <= 30 && !hasShot)
        {
            ShootMentaiko();
            hasShot = true;
        }
    }

    void ShootMentaiko()
    {
        Instantiate(
            mentaikoPrefab,
            transform.position + new Vector3(-2f, 0f, 0f),
            Quaternion.identity
        );
    }
}