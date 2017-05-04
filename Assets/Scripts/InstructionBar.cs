using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBar : MonoBehaviour {
	public float timeToDisappear;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDisappear);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
