using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
	private float duration;

	public GameObject resistanceSchool;
	public GameObject aclu;

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<RawImage>().mainTexture).Play();
		GetComponent<AudioSource> ().Play ();

		duration = ((MovieTexture)GetComponent<RawImage> ().mainTexture).duration;
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			resistanceSchool.SetActive (true);
			aclu.SetActive (true);
		}
	}

}
