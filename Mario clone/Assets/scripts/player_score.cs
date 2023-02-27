using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_score : MonoBehaviour {

	private float timeleft = 40;
	public int playerScore = 0;
	public GameObject timeleftUI;
	public GameObject playerScoreUI;

	void Update () {
		timeleft -= Time.deltaTime;
		timeleftUI.gameObject.GetComponent<Text> ().text = ("Time left: " + timeleft);
		playerScoreUI.gameObject.GetComponent<Text> ().text = ("Score " + playerScore);
		if (timeleft < 0.1f) {
			SceneManager.LoadScene ("Prototype_1");
		}
	}
	void onTriggerEnter2D (Collision2D trig) {
		Debug.Log ("Touched the end of level");
		CountScore ();
	}

	void CountScore (){
		playerScore = playerScore + (int)(timeleft * 10);
		Debug.Log (playerScore);
	}
}
