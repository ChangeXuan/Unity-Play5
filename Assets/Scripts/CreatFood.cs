using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFood : MonoBehaviour {

	public GameObject food;

	// Use this for initialization
	void Start () {

		for (int i = 2; i < 28; i++) {
			for (int j = 2; j< 31; j++) {
				GameObject playFood = GameObject.Instantiate (food);
				playFood.transform.position = new Vector2 (i, j);
				playFood.transform.parent = transform;
			}
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "food") {
			Destroy (collision.gameObject);
		}
	}
}
