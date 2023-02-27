using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour {

	public int EnemySpeed;
	public int XMoveDirection;

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.7f) {
			Flip ();
			if (hit.collider.tag == "Player") {
				SceneManager.LoadScene ("Prototype_1");
				Debug.Log ("You died");
			}
		}

	}
	void Flip (){
		if (XMoveDirection > 0) {
			XMoveDirection = -1;
		} else {
			XMoveDirection = 1;
		}
	}
}
