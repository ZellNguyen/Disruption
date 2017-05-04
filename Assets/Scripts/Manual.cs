using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour {

	public GameObject manualContent;
	public GameObject closeManual;
	public GameObject manual;

	// Use this for initialization
	void Start () {
		
		manualContent.SetActive (false);
		closeManual.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuPopsUp()
    {
		manualContent.SetActive (true);
		closeManual.SetActive (true);
		manual.transform.SetAsLastSibling();
    }

	public void CloseMenu()
	{
		manualContent.SetActive (false);
		closeManual.SetActive (false);
	}
}
