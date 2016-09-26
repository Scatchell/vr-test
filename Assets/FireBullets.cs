using UnityEngine;
using System.Collections;

public class FireBullets : MonoBehaviour {
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBullet", 3f, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBullet () {
		Instantiate (bullet);
	}
}
