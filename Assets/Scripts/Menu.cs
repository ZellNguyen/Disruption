using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	
	public void Play() {
		Hashtable arguments = new Hashtable ();
		SceneArgumentsManager.LoadScene ("Opener", arguments);
	}
}
