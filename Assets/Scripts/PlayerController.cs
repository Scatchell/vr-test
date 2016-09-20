﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;

	public float speed = 15;
	public Text scoreText;

	private int score = 0;

	void Start() {
		setScoreText ();
		rb = GetComponent<Rigidbody> ();
	}

	void setScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}

	void PrintControllerStatus(int index)
	{
		var device = SteamVR_Controller.Input(index);
		Debug.Log("index: " + device.index);
		Debug.Log("connected: " + device.connected);
		Debug.Log("hasTracking: " + device.hasTracking);
		Debug.Log("outOfRange: " + device.outOfRange);
		Debug.Log("calibrating: " + device.calibrating);
		Debug.Log("uninitialized: " + device.uninitialized);
		Debug.Log("pos: " + device.transform.pos);
		Debug.Log("rot: " + device.transform.rot.eulerAngles);
		Debug.Log("velocity: " + device.velocity);
		Debug.Log("angularVelocity: " + device.angularVelocity);

		var l = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
		var r = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
		Debug.Log((l == r) ? "first" : (l == index) ? "left" : "right");
	}


	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		var deviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestRight);

		var device = SteamVR_Controller.Input(deviceIndex);

		if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			device.TriggerHapticPulse(3000);
		}

		Vector3 movement = new Vector3(device.transform.pos.x, 0.0f, device.transform.pos.z);

		//Debug.Log (device.transform.pos);

		if (Input.GetKey (KeyCode.Q) && speed < 100) {
			speed += 1;
		}

		if (Input.GetKey (KeyCode.E) && speed > 0) {
			speed -= 1;
		}

		//rb.AddForce (movement * speed);

		Vector3 keyMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		//rb.AddForce (keyMovement * speed);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("TargetZone")) {
			Debug.Log ("collided");
			GetComponent<Renderer>().material.color = Color.cyan;
			score += 1;
			setScoreText ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("TargetZone")) {
			GetComponent<Renderer>().material.color = Color.green;
		}
	}
}
