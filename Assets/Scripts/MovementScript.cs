using UnityEngine;
using System.Collections;
using Valve.VR;

public class MovementScript : MonoBehaviour {
	public GameObject player;

	SteamVR_Controller.Device device;
	SteamVR_TrackedObject controller;

	Vector2 touchpad;

	private float sensitivityX = 1.5F;
	private Vector3 playerPos;
	public bool shouldMove;
	public static MovementScript instance;
	public Component cameraEye;

	void Start()
	{
		instance = this;
		shouldMove = true;
		controller = gameObject.GetComponent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update()
	{
		device = SteamVR_Controller.Input((int)controller.index);
		//If finger is on touchpad
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad) && shouldMove)
		{
			//Read the touchpad values
			touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

			player.transform.position += new Vector3(cameraEye.transform.forward.x, 0, cameraEye.transform.forward.z) * Time.deltaTime * (touchpad.y * 3f); 

			player.transform.position += new Vector3(cameraEye.transform.right.x, 0, cameraEye.transform.right.z) * Time.deltaTime * (touchpad.x * 3f); 

			//playerPos = player.transform.position;
			//playerPos.y = Terrain.activeTerrain.SampleHeight (player.transform.position);
			//player.transform.position = playerPos;
		}

		if (SteamVR_Controller.Input((int)controller.index).GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			device.TriggerHapticPulse(2000);
			BoxCollider boxColliderTemp = player.GetComponent<BoxCollider>();
			boxColliderTemp.center = new Vector3 (0, 1, 0);
			player.transform.position = new Vector3 (0,0,0);
			player.transform.eulerAngles = new Vector3 (0,0,0);
		}

		BoxCollider boxCollider = player.GetComponent<BoxCollider>();

		boxCollider.center = new Vector3(cameraEye.transform.localPosition.x, boxCollider.center.y, cameraEye.transform.localPosition.z);
		Vector3 size = boxCollider.size;
		boxCollider.size = new Vector3 (size.x, cameraEye.transform.localPosition.y, size.z);
		Vector3 center = boxCollider.center;
		boxCollider.center = new Vector3 (center.x, boxCollider.size.y / 2, center.z);
	}
}
