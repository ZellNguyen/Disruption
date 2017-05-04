using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoInfoManager : MonoBehaviour {
	public MovieTexture[] movies;
	public AudioClip[] audios;

	public GameObject video;

	private Hashtable arguments;

	private float duration;

	void Awake() {
		arguments = SceneArgumentsManager.GetSceneArguments ();

		if (arguments.ContainsKey ("Countries")) {
			List<string> countries = (List<string>)arguments ["Countries"];
			string country = countries [countries.Count - 1];

			switch (country as string) {
			case "Agraria": 
				video.GetComponent<RawImage> ().texture = movies [0];
				video.GetComponent<AudioSource> ().clip = audios [0];
				duration = movies [0].duration;
				break;
			case "Bahar": 
				video.GetComponent<RawImage> ().texture = movies [1];
				video.GetComponent<AudioSource> ().clip = audios [1];
				duration = movies [1].duration;
				break;
			case "Doah": 
				video.GetComponent<RawImage> ().texture = movies [2];
				video.GetComponent<AudioSource> ().clip = audios [2];
				duration = movies [2].duration;
				break;
			default:
				break;
			}
		}

	}

	// Use this for initialization
	void Start () {
		if (arguments.ContainsKey ("Iteration")) {
			int iteration = ((int)arguments ["Iteration"]) + 1;
			arguments ["Iteration"] = iteration;
		}
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			if ((int)arguments ["Iteration"] < 4)
				StartCoroutine (LoadOfficeScene (2f));
			else {
				StartCoroutine (WaitVideoFinish ("https://disruptiongameblog.wordpress.com/ptsd/", 2f));
			}
		}
	}

	IEnumerator LoadOfficeScene(float delay) {
		yield return new WaitForSeconds (delay);
		SceneArgumentsManager.LoadScene ("Office", arguments);
	}

	IEnumerator WaitVideoFinish(string webLinkName, float delay)
	{
		yield return new WaitForSeconds(delay);
		Application.OpenURL(webLinkName);
	}
}
