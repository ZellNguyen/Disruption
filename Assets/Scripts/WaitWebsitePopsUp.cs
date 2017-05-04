using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWebsitePopsUp : MonoBehaviour {

    public int videoFinishedSeconds;
    public string webLinkName;

    // Use this for initialization
    void Start () {
        StartCoroutine(WaitVideoFinish());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitVideoFinish()
    {
        yield return new WaitForSeconds(videoFinishedSeconds);
        Application.OpenURL(webLinkName);
    }
}
