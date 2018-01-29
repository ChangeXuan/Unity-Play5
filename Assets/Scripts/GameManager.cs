using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private static GameManager _singleton;
	public static GameManager singleton {
		get {
			return _singleton;
		}
	}

	private Camera camera;
	private Vector3 playPoision;

	public float speed = 20f;

	// Use this for initialization
	void Start () {
		_singleton = this;
		camera = Camera.main;
	}

	public void gameOver() {
		//Time.timeScale = 0;
		playPoision = GameObject.Find ("play").GetComponent<Transform> ().position;
		Vector3 tempPosision = playPoision;
		tempPosision.z = camera.transform.position.z;
		playPoision = tempPosision;
		StartCoroutine (gameOverAnimation());
	}

	IEnumerator gameOverAnimation() {
		while (true) {
			camera.orthographicSize = Mathf.Lerp (camera.orthographicSize, 4, Time.deltaTime * speed);
			camera.transform.position = Vector3.Lerp (camera.transform.position, playPoision, Time.deltaTime * speed);

			if (Mathf.Abs(camera.orthographicSize-4) < 0.01f) {
				break;
			}
			yield return 0;
		}
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
