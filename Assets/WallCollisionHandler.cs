using UnityEngine;
using System.Collections;

public class WallCollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.CompareTag("Wall")) {
			var rb = this.GetComponent<Rigidbody> ();
			Debug.Log("test");
			gameObject.transform.position += otherObj.gameObject.transform.right * 0.1f;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}
}
