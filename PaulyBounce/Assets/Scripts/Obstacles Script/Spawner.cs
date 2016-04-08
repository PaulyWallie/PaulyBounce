using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject[] hands, coins;

	List<GameObject> handsForSpawning = new List<GameObject>();
	List<GameObject> coinsForSpawning = new List<GameObject>();

	public float minWaitHands, maxWaitHands, minYHands, maxYHands, minWaitCoins, maxWaitCoins, minYCoins, MaxYCoins;

	void Awake () {
		InitializeHands();
		InitializeCoins();
	}

	void Start () {
		StartCoroutine(SpawnRandomHands());
		StartCoroutine(SpawnRandomCoins());
	}

	void InitializeHands(){
	int index = 0;
	for (int i = 0; i < hands.Length * 3; i ++) {
		GameObject obj = Instantiate(hands[index], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
		handsForSpawning.Add(obj);
		handsForSpawning[i].SetActive (false);
		index ++;
		if(index == hands.Length) 
			index = 0;
		}
	}

	void shuffleHands(){
		for(int i = 0; i < handsForSpawning.Count; i++) {
			GameObject temp = handsForSpawning[i];
			int random = Random.Range(i, handsForSpawning.Count);
			handsForSpawning[i] = handsForSpawning[random];
			handsForSpawning[random] = temp;
		}
	}

	IEnumerator SpawnRandomHands(){
		yield return new WaitForSeconds (Random.Range(minWaitHands, maxWaitHands));
	
		int index = Random.Range(0, handsForSpawning.Count);
		while (true) {
			if(!handsForSpawning[index].activeInHierarchy) {
				handsForSpawning[index].SetActive(true);
				handsForSpawning[index].transform.position = new Vector3(transform.position.x, Random.Range(minYHands,maxYHands), 0);
				break;
			} else {
				index = Random.Range(0, handsForSpawning.Count);
			}
		}

		StartCoroutine(SpawnRandomHands());

		}

	void InitializeCoins(){
	int index = 0;
	for (int i = 0; i < coins.Length * 3; i ++) {
		GameObject obj = Instantiate(coins[index], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
		coinsForSpawning.Add(obj);
		coinsForSpawning[i].SetActive (false);
		index ++;
		if(index == coins.Length) 
			index = 0;
		}
	}


		void shuffleCoins(){
		for(int i = 0; i < handsForSpawning.Count; i++) {
			GameObject temp = coinsForSpawning[i];
			int random = Random.Range(i, coinsForSpawning.Count);
			coinsForSpawning[i] = coinsForSpawning[random];
			coinsForSpawning[random] = temp;
		}
	}

	IEnumerator SpawnRandomCoins(){
		yield return new WaitForSeconds (Random.Range(minWaitCoins, maxWaitCoins));
	
		int index = Random.Range(0, coinsForSpawning.Count);
		while (true) {
			if(!coinsForSpawning[index].activeInHierarchy) {
				coinsForSpawning[index].SetActive(true);
				coinsForSpawning[index].transform.position = new Vector3(transform.position.x, Random.Range(minYCoins,maxYCoins), 0);
				break;
			} else {
				index = Random.Range(0, coinsForSpawning.Count);
			}
		}

		StartCoroutine(SpawnRandomCoins());

		}
}
