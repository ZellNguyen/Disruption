using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IterationManager : MonoBehaviour {
	public Sprite[] sprites = new Sprite[3];

	private Hashtable arguments;
	// Use this for initialization
	void Awake () {
		arguments = SceneArgumentsManager.GetSceneArguments ();

		if (arguments.ContainsKey ("Iteration")) {
			int iteration = (int)arguments ["Iteration"];

			switch (iteration) {
			case 1:
				if (sprites [0] != null)
					GetComponent<Image> ().sprite = sprites [0];
				else
					gameObject.SetActive (false);
				break;
			case 2:
				if (sprites [1] != null)
					GetComponent<Image> ().sprite = sprites [1];
				else
					gameObject.SetActive (false);
				break;
			case 3:
				if (sprites [2] != null)
					GetComponent<Image> ().sprite = sprites [2];
				else
					gameObject.SetActive (false);
				break;
			default:
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
