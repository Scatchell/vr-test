using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public Component cameraEye;
	private int throttle = 0;
	private int maxThrottle = 1;
	private bool rotateBack = false;
	private bool hit = false;
	private Vector3 originalPosition = new Vector3 (0, 0, 0);
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (rotateBack == true) {
			Quaternion rotation = gameObject.transform.rotation;
			float step = 2.0f * Time.deltaTime;

			gameObject.transform.rotation = Quaternion.RotateTowards (rotation, originalRotation, 1.0f);

			Debug.Log ("Move back");

			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, originalPosition, step);

//			Debug.DrawRay(gameObject.transform.position, new Vector3(0,0,0), Color.red);

			//Vector3.SqrMagnitude(lhs - rhs) < 1f
			if (Vector3.SqrMagnitude(transform.rotation.eulerAngles - originalRotation.eulerAngles) <= .2f && Vector3.SqrMagnitude(transform.position - originalPosition) <= .2f) {	
				rotateBack = false;
				MovementScript.instance.shouldMove = true;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().isKinematic = false;
			}
		}

		if (throttle > maxThrottle) {
			float camX = cameraEye.transform.eulerAngles.x;
			float camY = cameraEye.transform.eulerAngles.y;
			float camZ = cameraEye.transform.eulerAngles.z;
			//gameObject.transform.loc
			//Debug.Log ("Before Camera:" + cameraEye.transform.rotation.eulerAngles);
			//Debug.Log ("Before Game object:" + transform.rotation.eulerAngles);
			//Debug.Log ("Before Camera:" + cameraEye.transform.localEulerAngles);

			//ChildWorldTransform = ChildLocalTransform * ParentWorldTransform;

			//Quaternion.RotateTowards (gameObject.transform.rotation, cameraEye.transform.rotation, 10f);

			float parentObjectY = gameObject.transform.eulerAngles.y;
			float cameraEyeY = cameraEye.transform.eulerAngles.y;

			float yDiff = parentObjectY - cameraEyeY;

			Quaternion cameraRotation = cameraEye.transform.rotation;

			//gameObject.transform.rotation = cameraRotation;
			//gameObject.transform.rotation = cameraRotation;

			//Quaternion rotateTowards = Quaternion.RotateTowards (gameObject.transform.rotation, cameraEye.transform.rotation, 10f);

			//gameObject.transform.rotation = rotateTowards;
			//cameraEye.transform.localEulerAngles = new Vector3(0,0,0);

			//Debug.Log ("Diff: " + yDiff);
		
			//gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x, camY, gameObject.transform.eulerAngles.z);
			//cameraEye.transform.eulerAngles = new Vector3 (camX,camY,camZ);

			//Debug.Log ("Camera:" + cameraEye.transform.rotation.eulerAngles.y);
			//Debug.Log ("Game object:" + transform.rotation.eulerAngles.y);
			//Debug.Log ("Local Camera:" + cameraEye.transform.localEulerAngles);

			throttle = 0;
		} else {
			throttle += 1;
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.CompareTag ("Bullet") && MovementScript.instance.shouldMove) {
			MovementScript.instance.shouldMove = false;
			originalPosition = gameObject.transform.position;
			originalRotation = gameObject.transform.rotation;
			Debug.Log ("Collision with player!" + originalPosition);
			Debug.Log ("Collision with player!" + originalRotation.eulerAngles);
			Invoke ("SetRotateBackFlag", 2f);
		}
	}

	void SetRotateBackFlag() {
		rotateBack = true;
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
