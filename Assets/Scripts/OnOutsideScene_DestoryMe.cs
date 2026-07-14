using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 画面の外に出ると、自分自身を削除する
public class OnOutsideScene_DestroyMe : MonoBehaviour {

	bool showFlag = false;

	void LateUpdate() { // ずっと行う（一定時間ごとに）
		if (GetComponent<Renderer>().isVisible) {
			// １回表示されたあと
			showFlag = true;
		} else {
			if (showFlag) {
				// 画面の外に出て消えたら、削除する
				Destroy(this.gameObject);
			}
		}
	}
}
