using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
	public Transform[] spawnPositions;
	public GameObject[] whatToSpawn;
	public static int numberObjects = 0;
	public int maxObjects = 10;
	public float threshold = 0.8f;
	public float spawnTime = 0.1f;


	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("SpawnSomething", spawnTime, spawnTime);
	}
	void SpawnSomething() {
		float willSpawn = Random.Range (0.0f, 1.0f);

		if (willSpawn < (threshold - ((float)threshold/(float)maxObjects) * (numberObjects))) {
			
			int randomItem = Random.Range (0, whatToSpawn.Length);
			int randomLocation = Random.Range (0, spawnPositions.Length);
			Instantiate (whatToSpawn [randomItem], spawnPositions[randomLocation].transform.position, spawnPositions[randomLocation].transform.rotation);
			numberObjects = numberObjects + 1;
		}
	}
}
