using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
