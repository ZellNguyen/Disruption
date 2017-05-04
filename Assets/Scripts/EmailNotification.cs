using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailNotification : MonoBehaviour {
	private int count = 0;

	public Transform emailScreen;
	public GameObject emailLabel;

	void Awake() {
		gameObject.SetActive (false);

		Invoke ("Notify", 15f);
	}

	// Use this for initialization
	void Start () {
		foreach (Transform child in emailScreen) {
			if (child.gameObject.activeSelf)
				count++;
		}
		count--;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Notify() {
		gameObject.SetActive (true);
		GetComponent<AudioSource> ().Play ();
		emailLabel.SetActive (true);
	}

	public void Read() {
		count--;
		CheckIfReadAll ();
	}

	private void CheckIfReadAll() {
		if (count == 0) {
			gameObject.SetActive (false);
		}
	}
}
