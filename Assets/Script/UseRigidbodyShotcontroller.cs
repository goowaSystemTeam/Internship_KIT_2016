using UnityEngine;
using System.Collections;

public class UseRigidbodyShotcontroller : MonoBehaviour {

	public GameObject bullet;   //弾丸オブジェクトのプレファブ
	public Transform muzzle;    //銃口の位置を取得する用
	public float bulletSpeed = 3000;

	//毎フレーム実行する
	void Update(){

		//マウスを左クリックした時一度だけ実行する。
		if(Input.GetMouseButtonDown(0)){
			//弾丸を発車する関数を実行する。
			Shot();
		}
	}

	//弾丸を生成し、飛ばす
	void Shot(){

		//弾丸を作成する
		GameObject b = GameObject.Instantiate(bullet, muzzle.position, Quaternion.identity) as GameObject;//GameObject型に変換する。

		//銃口の前方にbulletSpeed分の力を加える。
		b.GetComponent<Rigidbody>().AddForce(muzzle.forward * bulletSpeed);
	}
}