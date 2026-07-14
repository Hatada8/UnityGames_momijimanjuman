using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する（水平に）
public class OnKeyPress_shot : MonoBehaviour {

    public GameObject bulletPrefab;
    public float bulletScale = 0.2f; // 弾のサイズ（0.5倍など）
    public float speed; // スピード：Inspectorで指定
    Rigidbody2D rbody;
    public GameObject showObjectName;   // 表示オブジェクト名：Inspectorで指定


    void Start () { // 最初に行う
		// 重力を0にして、衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		rbody.gravityScale =0;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (showObjectName != null)
        {
            showObjectName.SetActive(false);
        } // 消す
	}

    void Update() { // ずっと行う

        if (Input.GetKeyDown(KeyCode.Space)) { // もし、sキーが押されたら

            if (showObjectName != null)
                showObjectName.SetActive(true); // 消していたものを表示する
            GameObject bullet = Instantiate(bulletPrefab);
            // 位置をプレイヤーの位置に合わせる
            bullet.transform.position = transform.position + new Vector3(2.0f, 0f, 0f);
            bullet.transform.localScale = new Vector3(bulletScale, bulletScale, 1f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
    }
}
