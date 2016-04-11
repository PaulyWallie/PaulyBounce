using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {

	public float speed;

	private Rigidbody2D myBody;
	
	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		myBody.velocity = new Vector2 (speed, 0);
	}
}
