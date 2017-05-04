using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManagement : MonoBehaviour {
	public Sprite[] backgrounds;
	public GameObject background;
	public StrikePointRandomizer strikePoints;

	public PowerController powerController;
	public Text bombLeftText;

	private int kills = 0;
	private Hashtable argument;

	private int numberOfStrikes;

	void Awake() {
		argument = SceneArgumentsManager.GetSceneArguments ();
		List<string> countries = (List<string>)argument ["Countries"];
		string country = countries [countries.Count - 1];

		switch (country as string) {
		case "Agraria": 
			background.GetComponent<SpriteRenderer> ().sprite = backgrounds [0];
			break;
		case "Bahar": 
			background.GetComponent<SpriteRenderer> ().sprite = backgrounds [1];
			break;
		case "Doah": 
			background.GetComponent<SpriteRenderer> ().sprite = backgrounds [2];
			break;
		default:
			break;
		}

		int iteration = (int)argument ["Iteration"];
		switch (iteration) {
		case 1:
			powerController.speed = 20;
			break;
		case 2:
			powerController.speed = 50;
			break;
		case 3:
			powerController.speed = 80;
			break;
		default:
			break;
		}

		numberOfStrikes = strikePoints.numberOfPoints;
	}

	// Use this for initialization
	void Start () {
		if (!argument.ContainsKey ("Kills"))
			argument.Add ("Kills", 0);
	}
	
	// Update is called once per frame
	void Update () {
		int bombLeft = powerController.limitStrike;
		bombLeftText.text = "Bomb Left: " + bombLeft.ToString ();
		if (numberOfStrikes <= 0 || bombLeft <= 0)
			StartCoroutine (LoadVideoScene());
	}

	public void AddKills(int kills) {
		numberOfStrikes--;
		this.kills += kills;

		argument ["Kills"] = this.kills;
	}

	public int GetKills() {
		return this.kills;
	}

	IEnumerator LoadVideoScene() {
		yield return new WaitForSeconds (1.2f);
		SceneArgumentsManager.LoadScene ("Video", argument);
	}
}
