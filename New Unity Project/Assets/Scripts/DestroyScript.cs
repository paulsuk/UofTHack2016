using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	public float destroyTime = 3.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
		RandomSpawn.numberObjects = RandomSpawn.numberObjects - 1;
	
	}
	
	// Update is called once per frame

}
