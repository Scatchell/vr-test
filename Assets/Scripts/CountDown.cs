using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {
	public Component sphere;
	public Component cube;
	public Text gameOverText;

	private float timer = 60;
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			GetComponent<Text> ().text = "Remaining: " + timer.ToString ("F0") + " seconds";
		}

		if (timer <= 0) {
			sphere.gameObject.SetActive (false);
			cube.gameObject.SetActive (false);
			gameOverText.gameObject.SetActive (true);
		}
	}
}
