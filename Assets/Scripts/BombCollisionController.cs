using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionController : MonoBehaviour {
	
	public float speed;

	private GameSystemManagement gameSystem;

	void Awake() {
		gameSystem = GameObject.Find ("GameManager").GetComponent<GameSystemManagement> ();
	}

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Target") {
			Destroy (gameObject, 0.2f);

			float distance = Vector3.Distance (transform.position, collider.transform.position);
			int kills = ConvertDistanceToKills (distance);

			gameSystem.AddKills (kills);

			Destroy (collider.gameObject, 0.2f);
		}
	}

	int ConvertDistanceToKills(float distance) {
		return (int)Mathf.Floor(100f/distance);
	}
}
