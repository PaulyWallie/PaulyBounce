using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	public AudioClip jumpClip;

	public Rigidbody2D rigidBody;

	public int movementSpeed, waitTime;

	bool hasHitCeiling;
	 
	void Update () {
	}

	public void MoveRight(){
		transform.position += Vector3.right * Time.deltaTime * movementSpeed;
	}

	public void MoveLeft(){
		transform.position += Vector3.left * Time.deltaTime * movementSpeed; 	 
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag =="Ceiling"){
			rigidBody.drag = 1;
			hasHitCeiling = true;
			if(other.gameObject.tag =="Hands"){
				StartCoroutine(ChangeBounce());
			}
		}
	}

	 IEnumerator ChangeBounce(){
	 	yield return new WaitForSeconds(waitTime);
	 	rigidBody.drag = 0f;
	 	hasHitCeiling = false; 
	 }
}
