using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy_health : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -5) {
			Destroy (gameObject);
		}
	}
}
