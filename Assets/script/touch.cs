using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class touch : MonoBehaviour {

	public AudioClip voice_01;
	public AudioClip voice_02;


	public RectTransform fukidashi;
	public Text fukidashiMsg;

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

			if (Physics.Raycast (ray, out hit, 1000000)) {

				hitObject = hit.collider.gameObject;
				if (hitObject.gameObject.tag == "player") {
					Debug.Log ("hit");

					fukidashiMsg.text="text2";

					DispMsg.dispMessage ("hello");
				} 
				else if (hitObject.gameObject.tag == "Head") {
					//Debug.Log ("hit");

					//fukidashi.localScale = new Vector3(0.5f,0.5f,1);
					fukidashiMsg.text = "Test";

					DispMsg.dispMessage ("good");
				}
			}
				
	}
}
}
