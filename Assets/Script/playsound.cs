using UnityEngine;
using System.Collections;

public class playsound : MonoBehaviour {

	private AudioSource sound01;

	// Use this for initialization
	void Start () {

		sound01 = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			sound01.PlayOneShot (sound01.clip);

		}
	
	}
}
