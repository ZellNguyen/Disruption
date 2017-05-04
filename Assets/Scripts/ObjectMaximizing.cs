using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMaximizing : MonoBehaviour {
	private Vector2 canvasSize;

	private RectTransform rectTransform;
	Vector2 originalScale;
	Vector2 originalPosition;

	private Vector2 destinationScale;
	private float animationTime = 0.5f;

	private bool isMaximized;

	private bool isBeingResized;

	private GameObject canvas;
	private Transform parent;

	void Awake() {
		rectTransform = GetComponent<RectTransform> ();
		originalScale = rectTransform.localScale;
		originalPosition = rectTransform.localPosition;

		canvasSize = GameObject.Find ("Canvas").GetComponent<CanvasScaler> ().referenceResolution;
		float scaleRatio = canvasSize.y / rectTransform.sizeDelta.y;
		destinationScale = new Vector2 (scaleRatio * 0.8f, scaleRatio * 0.8f);

		canvas = GameObject.Find ("Canvas");
		parent = transform.parent;
	}

	public void Maximize() {
		transform.SetAsLastSibling ();
		StartCoroutine(Resize(destinationScale, Vector2.zero, animationTime));
		isMaximized = true;
	}
		
	public void Minimize() {
		StartCoroutine (Resize (originalScale, originalPosition,animationTime));
		isMaximized = false;
	}

	public void TriggerResize() {
		if (!isBeingResized) {
			if (!isMaximized) {
				MinimizeSibling ();
				transform.SetParent (canvas.transform);
				Maximize ();
			}
			else {
				transform.SetParent (parent);
				Minimize ();
			}
		}
	}

	IEnumerator Resize(Vector2 destinationScale, Vector2 destinationPosition, float time) {
		isBeingResized = true;
		Vector2 currentScale = rectTransform.localScale;
		Vector2 currentPosition = rectTransform.localPosition;

		float currentTime = 0.0f;

		while (currentTime / time < 1f) {
			currentTime += Time.deltaTime;
			rectTransform.localScale = Vector2.Lerp (currentScale, destinationScale, currentTime / time);
			rectTransform.localPosition = Vector2.Lerp (currentPosition, destinationPosition, currentTime / time);
			yield return null;
		};

		isBeingResized = false;
	}

	void MinimizeSibling () {
		foreach(Transform interactableObject in transform.parent) {
			if (interactableObject.name != transform.name && interactableObject.tag == "Interactable" && interactableObject.gameObject.activeSelf) {
				interactableObject.GetComponent<ObjectMaximizing> ().Minimize ();
			}
		}
	}
}
