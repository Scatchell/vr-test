using UnityEngine;
using System.Collections;

public class FireBullets : MonoBehaviour {
	public GameObject bullet;
	private static float INITIAL_SPAWN_TIME = 2f;
	private float spawnTime;
	private float startTime = 1f;
	private int level = 1;

	private const int MAX_LEVELS = 2;
	private const int MIN_RANGE = -4;
	private const int MAX_RANGE = 4;

	// Use this for initialization
	void Start () {
		spawnTime = INITIAL_SPAWN_TIME;
		Invoke ("SpawnBullet", startTime);
		InvokeRepeating ("ReduceSpawnTime", startTime, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBullet () {
		if (level >= 1) {
			int randomX = Random.Range (MIN_RANGE, MAX_RANGE);

			Vector3 randomPosition = new Vector3 (randomX, 1, -4);

			Instantiate (bullet, randomPosition, Quaternion.Euler (new Vector3 (90, 0, 0)));
		}

		if (level >= 2) {
			int randomZ = Random.Range (MIN_RANGE, MAX_RANGE);

			Vector3 randomPosition = new Vector3 (-4, 1, randomZ);

			Instantiate (bullet, randomPosition, Quaternion.Euler (new Vector3 (90, 90, 0)));
		}

		if (level >= 3) {
			int randomX = Random.Range (MIN_RANGE, MAX_RANGE);

			Vector3 randomPosition = new Vector3 (randomX, 1, 4);

			Instantiate (bullet, randomPosition, Quaternion.Euler (new Vector3 (90, 180, 0)));
		}

		if (level >= 4) {
			int randomZ = Random.Range (MIN_RANGE, MAX_RANGE);

			Vector3 randomPosition = new Vector3 (4, 1, randomZ);

			Instantiate (bullet, randomPosition, Quaternion.Euler (new Vector3 (90, 270, 0)));
		}

		Invoke ("SpawnBullet", spawnTime);
	}

	void ReduceSpawnTime () {
		if (spawnTime > 0.6f) {
			spawnTime -= 0.2f;
		} else if (level < MAX_LEVELS){
			level += 1;
			spawnTime = INITIAL_SPAWN_TIME;
		}
	}
}
