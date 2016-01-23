using UnityEngine;
using System.Collections;
using System;

public class playerMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	[SerializeField]
	private float maxSpeed;
	[SerializeField]
	private float acceleration;
	[SerializeField]
	private float jumpForce;

	private float currSpeed = 0;
	private bool isGround = false;
	private bool isJump = false;
	

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		HandleInput ();

		HandleMovement (horizontal);

	}

	void OnCollisionEnter(Collision col){
		Debug.Log (col.collider.name);
		if(col.collider.name == "Bottom"){
			isGround = true;
			Debug.Log (isGround);
		}
	}

	private void HandleInput(){
		if (Input.GetKeyDown(KeyCode.Space)){
			isJump = true;
		}
	}

	private void HandleMovement(float horizontal){
		if (horizontal > 0) {
			if (currSpeed > 0) {
				currSpeed = currSpeed + acceleration;
			} else {
				currSpeed = acceleration;
			}
			currSpeed = Math.Min (currSpeed, maxSpeed);
			myRigidBody.velocity = new Vector2 (horizontal * currSpeed, myRigidBody.velocity.y);
		} else if (horizontal < 0) {
			if (currSpeed < 0) {
				currSpeed = currSpeed - acceleration;
			} else {
				currSpeed = -acceleration;
			}
			currSpeed = Math.Max (currSpeed, -1 * maxSpeed);
			myRigidBody.velocity = new Vector2 (-1 * horizontal * currSpeed, myRigidBody.velocity.y);
		} else {
				currSpeed = 0;
				myRigidBody.velocity = new Vector2 (currSpeed, myRigidBody.velocity.y);	
		}
		if(isGround && isJump){
			isGround = false;
			myRigidBody.AddForce(new Vector2(0, jumpForce));
			Debug.Log("Jump!");
		}

	}
}


