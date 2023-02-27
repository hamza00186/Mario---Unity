using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = true;
	public int playerJumpPower = 1250;
	public float moveX;
	public bool isGrounded;

	// Update is called once per frame
	void Update () {
		playerMove ();
		PlayerRaycast ();
	}

	void playerMove() {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true){
			jump();
		}
		//ANIMATIONS
		//PLAYER DIRECTIONS
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		}
		else if (moveX > 0.0f && facingRight == true){
			FlipPlayer ();
		}
		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void jump() {
		//JUMPING CODE
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}
	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
	void OnCollisionEnter2D (Collision2D col){
		

	}
	void PlayerRaycast () {
		//TODO Fix this disguting code

		//RAY UP
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < 0.9f && rayUp.collider.tag == "collectible") {
			Destroy (rayUp.collider.gameObject);
		}

			//RAY DOWN
		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag == "enemy") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);

			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			rayDown.collider.gameObject.GetComponent<EnemyMove> ().enabled = false;
			//Destroy (hit.collider.gameObject);
		}
		if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag != "enemy") {
			isGrounded = true;
		}
	}
}
