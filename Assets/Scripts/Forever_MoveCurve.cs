using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと移動する（カーブしながら）
public class Forever_MoveCurve : MonoBehaviour
{
    public float speed = 1f;      // 横方向の速さ
    public float curveSize = 0.5f; // 曲がる大きさ
    public float curveSpeed = 2f;  // 曲がる速さ

    float time = 0f;

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        // 横に進みながら、上下に波のように動く
        float moveX = speed * Time.fixedDeltaTime;
        float moveY = Mathf.Sin(time * curveSpeed) * curveSize * Time.fixedDeltaTime;

        transform.Translate(moveX, moveY, 0);
    }
}