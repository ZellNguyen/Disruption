using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour {
	public float leftEnd;
	public float rightEnd;

	public float speed;

	public GameObject bombPrefab;
	public Transform bombsParent;
	public GameObject readyBar; 

	private bool isMovingLeft; 
	private bool isStriking = false;
	private bool isReady = false;

	public int limitStrike;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isReady = readyBar.GetComponent<ReadyBar> ().isReady;

		if (!isStriking)
			Oscillate ();
		if (Input.GetKeyDown (KeyCode.Space) && isReady) {
			limitStrike--;
			StartCoroutine (Strike ());
		}
	}

	IEnumerator Strike() {
		isStriking = true;
		readyBar.GetComponent<ReadyBar> ().readyLevel = 0.1f;

		GameObject bomb = (GameObject)Instantiate (bombPrefab, transform.position, Quaternion.identity);
		bomb.transform.parent = bombsParent;
		yield return new WaitForSeconds (0.5f);
		isStriking = false;
	}

	void Oscillate() {
		float step = speed * Time.deltaTime;
		if (transform.localPosition.x <= leftEnd)
			isMovingLeft = false;
		else if (transform.localPosition.x >= rightEnd)
			isMovingLeft = true;

		Vector2 direction = isMovingLeft ? Vector2.right * leftEnd : Vector2.right * rightEnd;
		transform.localPosition = Vector2.MoveTowards (transform.localPosition, direction, step); 
	}
}
