using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public Component cameraEye;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, cameraEye.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		//Debug.Log (cameraEye.transform.rotation);
	}
}
