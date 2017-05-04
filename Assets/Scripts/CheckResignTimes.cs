using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResignTimes : MonoBehaviour {

	public int maxResignTime;
	public GameObject resignButton;
	public static int resignButtonUsedTimes;
	public static CheckResignTimes instance = null;

	// Use this for initialization
	void Start () {

		// create instance
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		resignButton = GameObject.Find ("ResignButton");
		checkResignTimes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkResignTimes(){

		// default use of resign button is zero, we may use resign button for maximum three times, so I calculate the used times here rather than use boolean
		// check if already used up to the maximum times
		if (resignButtonUsedTimes < maxResignTime) {
			resignButton.SetActive (true);
		} 

		else if(resignButton != null){
			resignButton.SetActive (false);
		}
	}
}
