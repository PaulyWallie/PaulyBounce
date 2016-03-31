using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed = 0.1f;

	private Vector2 offSet = Vector2.zero;
	private Material mat;

	void Start () {
		mat = GetComponent<Renderer> ().material;
		offSet = mat.GetTextureOffset("_MainTex");
	}
	

	void Update () {
		offSet.x += speed * Time.deltaTime;
		mat.SetTextureOffset ("_MainTex", offSet);
	}
}
