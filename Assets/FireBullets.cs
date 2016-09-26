using UnityEngine;
using System.Collections;

public class FireBullets : MonoBehaviour {
	public GameObject bullet;
	private float spawnTime = 3f;
	private float startTime = 5f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnBullet", startTime);
		InvokeRepeating ("ReduceSpawnTime", startTime, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBullet () {
		Instantiate (bullet);
		Invoke ("SpawnBullet", spawnTime);
	}

	void ReduceSpawnTime () {
		if (spawnTime > .2f) {
			spawnTime -= 0.2f;
		}
	}
}
