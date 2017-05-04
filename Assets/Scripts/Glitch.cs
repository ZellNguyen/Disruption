using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glitch : MonoBehaviour {
	private Hashtable arguments;
	private float percentageOfGlitch;

	private bool isPlaying;
	private RawImage rawImage;

	void Awake() {
		arguments = SceneArgumentsManager.GetSceneArguments ();
		int iteration = (int)arguments ["Iteration"];

		switch (iteration) {
		case 1:
			percentageOfGlitch = 0f;
			break;
		case 2:
			percentageOfGlitch = 0.02f;
			break;
		case 3:
			percentageOfGlitch = 0.08f;
			break;
		default:
			break;
		}

		rawImage = GetComponent<RawImage> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool hit = Random.value < percentageOfGlitch ? true : false;
		if (!isPlaying && hit) {
			StartCoroutine (Play ());
		}
	}

	IEnumerator Play() {
		isPlaying = true;

		rawImage.enabled = true;
		((MovieTexture)rawImage.mainTexture).Play();
		GetComponent<AudioSource> ().Play ();

		float randomTime = Random.Range (0.3f, 1f);
		yield return new WaitForSeconds (randomTime);

		((MovieTexture)rawImage.mainTexture).Stop ();
		GetComponent<AudioSource> ().Stop ();

		rawImage.enabled = false;
		isPlaying = false;
	}
}
