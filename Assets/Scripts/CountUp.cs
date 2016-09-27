using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountUp : MonoBehaviour {
	public Text gameOverText;

	private float timer = 0;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		GetComponent<Text> ().text = "Time: " + timer.ToString ("F0") + " seconds";
	}
}
