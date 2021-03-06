﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Animator anim;

	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	// Use this for initialization
	void Start () {
		//Instantiate
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerMoving = false;

		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
			/*
			 * We Dont need to using translate, beacause what we need to controll(moving) player is x and y axis, instead x,y, and z
			 * */
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,myRigidbody.velocity.y);

			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f){

			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);

			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw("Vertical"));
		}


		//Give command to player, if dont moving object then the player have to in idle position
		if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f){
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}
		if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f){
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
		}


		//Give Animation to player movement, passing GetAxis Value (-1,0,1) to animation Paramenter (MoveX, MoveY) 
		anim.SetFloat ("MoveX",Input.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY",Input.GetAxisRaw("Vertical"));
		anim.SetBool ("PlayerMoving",playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
