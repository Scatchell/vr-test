using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public bool fire = true;
	private float speed = 7.0f;

	// Use this for initialization
	void Start () {
		int randomX = Random.Range (-8, 8);

		gameObject.transform.position = new Vector3 (randomX, 1, -8);
	}
	
	// Update is called once per frame
	void Update () {
		if (fire) {
			gameObject.transform.position += new Vector3 (0, 0, 1) * Time.deltaTime * speed;
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.tag == "Wall") {
			Destroy(gameObject);
		}
	}
}
