using UnityEngine;
using System.Collections;

public class DispMsg : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public static int lengthMsg;
	public static bool flgDisp = false;
	public static float waitTime = 0;
	public static string dispMsg;

	public static void dispMessage (string msg){

		dispMsg=msg;
	}

	//float nextTime=0;
	
	// Update is called once per frame
	void Update () {
	
	}

	/*if(Time.Time>nextTime){

		if(lengthMsg<DispMsg.Length){

			lengthMsg++;
		}

		nextTime=Time.time+0.01f;
	}*/
	public GUIStyle msgWnd;

	void OnGUI(){
		//画面の幅
		const float screenWidth=1136;

		//ウインドウの座標
		const float msgwWidth=800;
		const float msgwHeight = 200;
		const float msgwPosX = (screenWidth - msgwWidth) / 2;
		const float msgwPosY = 390;

		//画面の幅から1ピクセルを算出
		float factorSize=Screen.width/screenWidth;

		float msgwX;
		float msgwY;
		float msgwW = msgwWidth * factorSize;
		float msgwH = msgwHeight * factorSize;

		//フォント
		GUIStyle myStyle=new GUIStyle();
		myStyle.fontSize = (int)(30 * factorSize);

		/*GUI.Label (new Rect (msgwW, msgwY, msgwW, msgwH), dispMsg.
			Substring (0, lengthMsg), myStyle);*/
		//メッセージ表示
		if(flgDisp==true){

			//ウインドウ
			msgwX=msgwPosX*factorSize;
			msgwY = msgwPosY * factorSize;
			GUI.Box (new Rect (msgwX, msgwY, msgwW, msgwH), "ウインドウ", msgWnd);

			//メッセージ
			myStyle.normal.textColor=Color.white;

			msgwX = (msgwPosX + 20) * factorSize;
			msgwY = (msgwPosY + 20) * factorSize;
			GUI.Label (new Rect (msgwX, msgwY, msgwW, msgwH), "メッセージ", myStyle);
		}

}
}