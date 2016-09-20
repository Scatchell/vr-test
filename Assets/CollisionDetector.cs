using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collision!!!");

		//MovementScript.instance.shouldMove = false;
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		//GetComponent<Renderer>().material.color = Color.cyan;
	}
}
