using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;

	public float speed = 15;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		if (Input.GetKey (KeyCode.Q) && speed < 100) {
			speed += 1;
		}

		if (Input.GetKey (KeyCode.E) && speed > 0) {
			speed -= 1;
		}

		rb.AddForce (movement * speed);
	}
}
