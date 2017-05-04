using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {

	public GameObject creditContent;
	public GameObject closeCredit;
	public GameObject credit;

	// Use this for initialization
	void Start () {

		creditContent.SetActive (false);
		closeCredit.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CreditPopsUp()
	{
		creditContent.SetActive (true);
		closeCredit.SetActive (true);
		credit.transform.SetAsLastSibling();
	}

	public void CloseCredit()
	{
		creditContent.SetActive (false);
		closeCredit.SetActive (false);
	}
}
