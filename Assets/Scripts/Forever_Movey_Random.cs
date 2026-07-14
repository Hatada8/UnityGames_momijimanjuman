using UnityEngine;

public class Forever_Movey_Random : MonoBehaviour
{
    public float speedX = -0.7f; // 左に進む
    public float speedY = 0.5f;  // 上下の最大スピード

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;


    private float vx;
    private float vy;

    private float changeTime = 0f;

    void Start()
    {
        vx = speedX;
    }

    void Update()
    {
        // 一定時間ごとに上下方向をランダム変更
        changeTime -= Time.deltaTime;

        if (changeTime <= 0f)
        {
            vy = Random.Range(-speedY, speedY);
            changeTime = Random.Range(0.5f, 2f); // 次に変えるまでの時間
        }
    }

    void FixedUpdate()
    {
        transform.Translate(vx / 50f, vy / 50f, 0);
        Vector3 pos= transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}