using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opener : MonoBehaviour {
	private Hashtable arguments;

	private float duration;
	// Use this for initialization
	void Start () {
		arguments = new Hashtable ();

		arguments.Add ("Iteration", 1);
		arguments.Add ("Resigned", false);

		((MovieTexture)GetComponent<RawImage>().mainTexture).Play();
		GetComponent<AudioSource> ().Play ();

		duration = ((MovieTexture)GetComponent<RawImage> ().mainTexture).duration;
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		Debug.Log (duration);
		if (duration <= 0) 
			StartCoroutine(LoadOfficeScene (2f));
	}

	IEnumerator LoadOfficeScene(float delay) {
		yield return new WaitForSeconds (delay);
		SceneArgumentsManager.LoadScene ("Office", arguments);
	}
}
