using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray;
		RaycastHit hit;

		GameObject hitObject;
		if(Input.GetMouseButtonDown(0) ){

			//マウスカーソルの位置からカメラの画面を通してレイを飛ばす
			ray=Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100)) {

				hitObject = hit.collider.gameObject;
				if (hitObject.gameObject.tag == "player") {
					DispMsg.dispMessage ("アイウエオ");
				} else if (hitObject.gameObject.tag == "cube") {
					DispMsg.dispMessage ("カキクケコ");
				}
				Debug.Log ("hit");
			}
	
	}
}
}