using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyBar : MonoBehaviour {
	public float readyLevel = 0.1f;
	public float step;

	[HideInInspector]
	public bool isReady;

	private Vector2 originScale;

	// Use this for initialization
	void Start () {
		originScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (readyLevel < 1f) {
			isReady = false;
			readyLevel += step * Time.deltaTime;
		}
		else {
			readyLevel = 1f;
			isReady = true;
			Debug.Log ("Is Ready!");
		}

		transform.localScale = new Vector2 (originScale.x, originScale.y * readyLevel);
	}
}
