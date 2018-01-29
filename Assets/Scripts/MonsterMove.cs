using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

	public GameObject pathPrefabs;
	public float speed = 0.2f;

	private List<Vector3> pathList = new List<Vector3>();
	private int index = 0;
	private bool isOver = false;

	void Start () {
		foreach (Transform t in pathPrefabs.transform) {
			pathList.Add (t.position);
		}
	}

	void FixedUpdate () {
		if (!isOver) {
			if (transform.position != pathList [index]) {
				Vector2 temp = Vector2.MoveTowards (transform.position, pathList [index], speed);
				GetComponent<Rigidbody2D> ().MovePosition (temp);

				Vector2 dir = pathList [index] - transform.position;
				GetComponent<Animator> ().SetFloat ("DirX", dir.x);
				GetComponent<Animator> ().SetFloat ("DirY", dir.y);
			} else {
				index = (index + 1) % pathList.Count;
			}
		}

	}

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Player") {
			isOver = true;
			GameManager.singleton.gameOver ();
			Destroy (collision.gameObject);
		}
	}
}
