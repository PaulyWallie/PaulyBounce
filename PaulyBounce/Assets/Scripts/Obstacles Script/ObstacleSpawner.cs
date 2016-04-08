using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawning = new List<GameObject>();

	public float minWait, maxWait, minY, maxY;

	void Awake () {
		InitializeObstalces();
	}

	void Start () {
		StartCoroutine(SpawnRandomObstacles());
	}

	void InitializeObstalces() {
	int index = 0;
	for (int i = 0; i < obstacles.Length * 3; i ++) {
		GameObject obj = Instantiate(obstacles[index], new Vector3(transform.position.x,
																   transform.position.y, 0), Quaternion.identity) as GameObject;
		obstaclesForSpawning.Add(obj);
		obstaclesForSpawning[i].SetActive (false);
		index ++;
		if(index == obstacles.Length) 
			index = 0;
	}
}

	void Shuffle() {
		for(int i = 0; i < obstaclesForSpawning.Count; i++) {
			GameObject temp = obstaclesForSpawning[i];
			int random = Random.Range(i, obstaclesForSpawning.Count);
			obstaclesForSpawning[i] = obstaclesForSpawning[random];
			obstaclesForSpawning[random] = temp;
		}
	}

	IEnumerator SpawnRandomObstacles() {
		yield return new WaitForSeconds (Random.Range(minWait, maxWait));
	
		int index = Random.Range(0, obstaclesForSpawning.Count);
		while (true) {
			if(!obstaclesForSpawning[index].activeInHierarchy) {
				obstaclesForSpawning[index].SetActive(true);
				obstaclesForSpawning[index].transform.position = new Vector3(transform.position.x, Random.Range(minY,maxY), 0);
				break;
			} else {
				index = Random.Range(0, obstaclesForSpawning.Count);
			}
		}

		StartCoroutine(SpawnRandomObstacles());

		}

} // ObstacleSpaener
