﻿using UnityEngine;
using System.Collections;

public class PlayerMoves : MonoBehaviour {

	public float speed = 15.0F;
	public float jumpspeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//キャラクターを移動させる
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {

			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

			moveDirection = transform.TransformDirection (moveDirection);

			moveDirection *= speed;

			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpspeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move (moveDirection * Time.deltaTime);
		
	
	}

	void OnCollisionEnter(Collision other){
		Application.LoadLevel (Application.loadedLevel);
	}
}
