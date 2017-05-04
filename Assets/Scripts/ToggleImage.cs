using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour {
	public void Show() {
		ShowObject (gameObject);
	}

	public void Hide() {
		HideObject (gameObject);
	}

	private void ShowObject(GameObject obj) {
		obj.GetComponent<Image> ().enabled = true;
		obj.transform.SetAsLastSibling ();
			
		foreach (Transform child in obj.transform) {
			if(child.gameObject.activeSelf)
				child.GetComponent<Image> ().enabled = true;
		}
	}

	private void HideObject(GameObject obj) {
		obj.GetComponent<Image> ().enabled = false;
		if (obj.transform.childCount == 0) 
			return;

		foreach (Transform child in obj.transform) {
			if(child.gameObject.activeSelf)
				HideObject (child.gameObject);
		}
	}
}
