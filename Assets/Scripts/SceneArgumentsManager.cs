using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneArgumentsManager {
	static Hashtable sceneArguments;

	public static void LoadScene(string sceneName, Hashtable arguments) {
		sceneArguments = arguments;
		SceneManager.LoadScene (sceneName);
	}

	public static Hashtable GetSceneArguments() {
		return sceneArguments;
	}
}
