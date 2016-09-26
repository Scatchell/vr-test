using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public Component cameraEye;
	int throttle = 0;
	int maxThrottle = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
}
