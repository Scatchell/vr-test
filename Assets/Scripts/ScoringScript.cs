using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour {
	public Text healthText;
	public Text gameOverText;
	public Component timer;
	public Component canvas;

	private int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.CompareTag ("Bullet") && MovementScript.instance.shouldMove) {
			health -= 10;

			SetHealthText ();
		}
	}

	void SetHealthText() {
		if (health >= 0) {
			healthText.text = "Health: " + health.ToString ();

			if (health == 0) {	
				gameOverText.gameObject.SetActive (true);

				canvas.GetComponent<FireBullets> ().enabled = false;
				timer.GetComponent<CountUp> ().enabled = false;
			}
		}
	}

}
