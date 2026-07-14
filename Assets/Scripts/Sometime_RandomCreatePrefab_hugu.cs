using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ときどき、範囲内にランダムにプレハブを作る
public class Sometime_RandomCreatePrefab_hugu : MonoBehaviour {

	public GameObject newPrefab; // 作るプレハブ：Inspectorで指定
	public float intervalSec = 1; // 作成間隔（秒）：Inspectorで指定する

	void Start() { // 最初に行う
		// 指定秒ごとに、CreatePrefabをくり返し実行する予約
		InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
	}

	void CreatePrefab() {
		// このオブジェクトの範囲内にランダムに
		Vector3 area = GetComponent<SpriteRenderer>().bounds.size;

		Vector3 newPos = this.transform.position - transform.right * 1.0f;
		newPos.y += Random.Range(-0f, 0f);
		newPos.z = -5; // 手前に表示
		// プレハブを作る
		GameObject newGameObject = Instantiate(newPrefab);
		newGameObject.transform.position = newPos;
	}
}
