using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeOutputManager : MonoBehaviour {
	private Hashtable arguments = new Hashtable();

	void Awake() {
		arguments = SceneArgumentsManager.GetSceneArguments();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayAgraria() {
		LoadArguments ("Agraria");
		SceneArgumentsManager.LoadScene ("MiniGame", arguments);
	}

	public void PlayBahar() {
		LoadArguments ("Bahar");
		SceneArgumentsManager.LoadScene ("MiniGame", arguments);
	}

	public void PlayDoah() {
		LoadArguments ("Doah");
		SceneArgumentsManager.LoadScene ("MiniGame", arguments);
	}

	private void LoadArguments(string country) {
		List<string> countries = new List<string> ();
		if (arguments.ContainsKey ("Countries")) {
			countries = (List<string>)arguments ["Countries"];
			countries.Add (country);
			arguments ["Countries"] = countries;
		} else {
			countries.Add (country);
			arguments.Add ("Countries", countries);
		}
	}

	public void Resign(){
		arguments ["Resigned"] = true;
	}

	public void Resist() {
		SceneArgumentsManager.LoadScene ("ResistanceEnding", arguments);
	}
}
