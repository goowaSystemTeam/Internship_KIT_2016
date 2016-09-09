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

			if (Physics.Raycast (ray, out hit, 100000)) {

				hitObject = hit.collider.gameObject;

				if (hitObject.gameObject.tag == "desk") {
					Debug.Log ("hit");

					fukidashiMsg.text = "机";

				} else if (hitObject.gameObject.tag == "tana") {
					Debug.Log ("hit");

					//fukidashi.localScale = new Vector3(0.5f,0.5f,1);
					fukidashiMsg.text = "棚";

				} else if (hitObject.gameObject.tag == "key1") {
					Debug.Log ("hit");
					fukidashiMsg.text = "机の鍵";

				}else if (hitObject.gameObject.tag == "key2") {
					Debug.Log ("hit");
					fukidashiMsg.text = "部屋の鍵";

				}else if (hitObject.gameObject.tag == "book") {
					Debug.Log ("hit");
					fukidashiMsg.text = "本";

				}else if (hitObject.gameObject.tag == "tana2") {
					Debug.Log ("hit");
					fukidashiMsg.text = "本棚";

				}else if (hitObject.gameObject.tag == "gun") {
					Debug.Log ("hit");
					fukidashiMsg.text = "銃";

				}else if (hitObject.gameObject.tag == "diary") {
					Debug.Log ("hit");
					fukidashiMsg.text = "日記";

				}else if (hitObject.gameObject.tag == "wood") {
					Debug.Log ("hit");
					fukidashiMsg.text = "木";

				}
			}
				
	}
}
}
