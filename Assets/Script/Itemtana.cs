using UnityEngine;
using System.Collections;

public class Itemtana : MonoBehaviour
{
	// トリガーとの接触時に呼ばれるコールバック
	void OnTriggerEnter (Collider hit)
	{
		// 接触対象はPlayerタグですか？
		if (hit.CompareTag ("ballet")) {

			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
		}
	}
}