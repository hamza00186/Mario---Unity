using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PLAYERscore : MonoBehaviour {

	private float timeleft = 120;
	public int player_score = 0;
	public GameObject timeleftUI;
	public GameObject player_scoreUI;

	void Update () {
		timeleft -= Time.deltaTime;
		timeleftUI.gameObject.GetComponent<Text> ().text = ("Time Left: " +(int) timeleft);
		player_scoreUI.gameObject.GetComponent<Text> ().text = ("Score: " + player_score);
		if (timeleft < 0.1f) {
			SceneManager.LoadScene ("Prototype_1");
		}
	}
	void OnTriggerEnter2D (Collider2D trig){
		if (trig.gameObject.name == "endlevel") {
			Debug.Log ("Reached The end of Level");
			CountScore ();
		}
		if (trig.gameObject.tag == "collectible") {
			player_score += 10;
			Destroy (trig.gameObject);
		}
	}
	void CountScore () {
		player_score = player_score + (int)(timeleft * 10);
		Debug.Log (player_score);
	}
}

