using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	public AudioClip jumpClip;

	public Rigidbody2D rigidBody;

	public int movementSpeed;
	float horizontalMovement;

	void FixedUpdate () {
		Move(horizontalMovement);
	}

	void Move(float horizontalInput){

		Vector2 moveVel = rigidBody.velocity;
		moveVel.x = horizontalInput * movementSpeed * Time.deltaTime;
		rigidBody.velocity = moveVel;
	}

	public void StartMoving(float horizontalInput){
		horizontalMovement = horizontalInput;
	}
}

