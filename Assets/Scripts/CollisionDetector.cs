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
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		//rb.velocity = Vector3.zero;
		//rb.transform.eulerAngles = new Vector3 (0, 0, 0);
		//GetComponent<Renderer>().material.color = Color.cyan;
	}
}
