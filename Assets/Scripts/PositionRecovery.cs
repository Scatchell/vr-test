using UnityEngine;
using System.Collections;

public class PositionRecovery : MonoBehaviour {

	public Component cameraEye;
	private int throttle = 0;
	private int maxThrottle = 1;
	private bool rotateBack = false;
	private bool hit = false;
	private Vector3 originalPosition = new Vector3 (0, 0, 0);
	private Quaternion originalRotation;
	private float positionReturnSpeed = 2.0f;

	void Start () {
	
	}
	
	void Update () {

		if (rotateBack == true) {
			Quaternion rotation = gameObject.transform.rotation;
			float step = positionReturnSpeed * Time.deltaTime;

			gameObject.transform.rotation = Quaternion.RotateTowards (rotation, originalRotation, 1.0f);

			Debug.Log ("Returning to position: " + originalPosition);
			Debug.Log ("Returning to rotation: " + originalRotation);

			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, originalPosition, step);

//			Debug.DrawRay(gameObject.transform.position, new Vector3(0,0,0), Color.red);

			if (Vector3.SqrMagnitude(transform.rotation.eulerAngles - originalRotation.eulerAngles) <= .2f && Vector3.SqrMagnitude(transform.position - originalPosition) <= .2f) {	
				rotateBack = false;
				MovementScript.instance.shouldMove = true;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().isKinematic = false;
			}
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.CompareTag ("Bullet") && MovementScript.instance.shouldMove) {
			MovementScript.instance.shouldMove = false;
			originalPosition = gameObject.transform.position;
			originalRotation = gameObject.transform.rotation;

			Invoke ("SetRotateBackFlag", 2f);
		}
	}

	void SetRotateBackFlag() {
		rotateBack = true;
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
