using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	public AudioClip jumpClip;

	public Rigidbody2D rigidBody;

	public int movementSpeed;
	public float maxHeight, minHeight;
	float horizontalMovement;

	void FixedUpdate () {
		Move(horizontalMovement);
		Vector2 temp;
		if (temp =  new Vector2(this.transform.position.x, maxHeight)) {
			rigidBody.drag = 1;
		} else { 
			if (temp = new Vector2(this.transform.position.x, minHeight)) {
				rigidBody.drag = .05;
			}
		}
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