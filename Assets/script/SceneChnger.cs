using UnityEngine;
using System.Collections;

public class SceneChnger : MonoBehaviour {

	public string nextSceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			Application.LoadLevel (nextSceneName);
	}
}
}