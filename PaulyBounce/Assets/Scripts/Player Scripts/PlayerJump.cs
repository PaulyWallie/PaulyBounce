using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	public AudioClip jumpClip;

	public int movementSpeed;
	 
	void Update () {

	}

	public void MoveRight(){
		transform.position += Vector3.right * Time.deltaTime * movementSpeed;
	}

	public void MoveLeft(){
		transform.position += Vector3.left * Time.deltaTime * movementSpeed; 	 
	}
} 