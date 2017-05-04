using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResignCase : MonoBehaviour {
	[Header("Resign Letters")]
	public GameObject resignLetter;
	public Sprite crossedResignSprite;

	private Hashtable arguments;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void Resign() {
		Invoke ("ReceiveLetter", 1f);
	}

	void ReceiveLetter() {
		ResignRejected ();
		resignLetter.SetActive (true);
	}

	void ResignRejected() {
		GetComponent<Image> ().sprite = crossedResignSprite;
		GetComponent<Button> ().enabled = false;
	}
}
