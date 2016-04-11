using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public float timeAmount;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag =="Coins"){
			Invoke("DisableCoins", timeAmount);
		}
	}

	void DisableCoins(){
		gameObject.SetActive(false);
	}
}
