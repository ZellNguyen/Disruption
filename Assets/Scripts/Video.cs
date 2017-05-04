using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video : MonoBehaviour {
	private Hashtable arguments;

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<RawImage>().mainTexture).Play();
		GetComponent<AudioSource> ().Play ();


	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	arguments = SceneArgumentsManager.GetSceneArguments ();
		//	SceneArgumentsManager.LoadScene ("Office", arguments);
		//}
	}
}
