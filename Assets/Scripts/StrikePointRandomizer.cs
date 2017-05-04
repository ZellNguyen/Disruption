using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikePointRandomizer : MonoBehaviour {
	public GameObject strikePointPrefab;

	public int numberOfPoints;
	public Transform powerBar;

	public float leftEndX;
	public float rightEndX;

	// Use this for initialization
	void Start () {
		float leftX = leftEndX;
		float rightX = (rightEndX - leftEndX) / numberOfPoints;
		for (int i = 0; i < numberOfPoints; i++) {
			float x = Random.Range (leftX, leftX + rightX - 1f);
			float y = Random.Range (0, 2.5f);

			Vector2 randomPoint = new Vector2 (x, y);
			Debug.Log (x);
			Instantiate (strikePointPrefab, randomPoint, Quaternion.identity);
			leftX += rightX;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
