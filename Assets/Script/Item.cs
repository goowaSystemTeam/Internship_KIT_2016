using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public float destroyTime = 3;

	//このオブジェクト(Bullet)が生成された瞬間に実行される。
	void Start(){
		//このオブジェクトをdestroyTimeで指定した秒後に削除する。
		Destroy(gameObject, destroyTime);
	}

	// トリガーとの接触時に呼ばれるコールバック
	/*void OnTriggerEnter (Collider hit)
	{
		// このコンポーネントを持つGameObjectを破棄する
		Destroy(gameObject);
	}*/
}