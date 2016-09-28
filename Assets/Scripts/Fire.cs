using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public bool fire = true;
	private float speed = 7.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fire) {
			gameObject.transform.position += new Vector3(gameObject.transform.up.x, 0, gameObject.transform.up.z) * Time.deltaTime * speed;
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.tag == "Wall") {
			Destroy(gameObject);
		}
	}
}
