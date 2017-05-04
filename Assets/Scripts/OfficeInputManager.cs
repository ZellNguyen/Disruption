using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeInputManager : MonoBehaviour {
	private Hashtable arguments;

	[Header("Mission Buttons")]
	public GameObject missionButtons;
	public GameObject agrariaButton;
	public GameObject baharButton;
	public GameObject doahButton;

	[Header("Email")]
	public Image emailLabel;
	public Image emailImage;
	[Space(10)]
	public Sprite reviewSprite;
	public Sprite[] reviewContentSprite;
	[Space(10)]
	public Sprite badPerformanceLabel;
	public Sprite badPerformanceContent;
	[Space(10)]
	public Transform resistanceEmail;

	[Header("Resign...")]
	public GameObject resignButton;
	public Sprite crossedResignSprite;
	public GameObject resignLetters;

	[Header("Bulletin Board Items")]
	public GameObject agrariaTragedy;
	public GameObject agrariaReview;
	[Space(10)]
	public GameObject baharTragedy;
	public GameObject baharReview;
	[Space(10)]
	public GameObject doahTragedy;
	public GameObject doahReview;

	[Header("Map Notes")]
	public GameObject agrariaNote;
	public GameObject baharNote;
	public GameObject doahNote;

	private int iteration;
	private List<string> countries;

	void Awake() {
		arguments = SceneArgumentsManager.GetSceneArguments ();
		countries = arguments.ContainsKey("Countries") ? (List<string>)arguments ["Countries"] : new List<string>();
		iteration = arguments.ContainsKey("Iteration") ? (int) arguments ["Iteration"] : 0;
	}
	// Use this for initialization
	void Start () {

		// COUNTRIES STRIKED
		foreach (string country in countries) {
			switch (country) {
			case "Agraria":
				agrariaButton.SetActive (false);
				agrariaTragedy.SetActive (true);
				agrariaReview.SetActive (true);
				resignButton.GetComponent<RectTransform> ().localPosition = agrariaButton.GetComponent<RectTransform> ().localPosition;
				agrariaNote.SetActive (true);
	
				break;
			case "Bahar":
				baharButton.SetActive (false);
				baharTragedy.SetActive (true);
				baharReview.SetActive (true);
				resignButton.GetComponent<RectTransform> ().localPosition = baharButton.GetComponent<RectTransform> ().localPosition;
				baharNote.SetActive (true);

				break;
			case "Doah":
				doahButton.SetActive (false);
				doahTragedy.SetActive (true);
				doahReview.SetActive (true);
				resignButton.GetComponent<RectTransform> ().localPosition = doahButton.GetComponent<RectTransform> ().localPosition;
				doahNote.SetActive (true);

				break;
			default:
				break;
			}
		}

		//ITERATION
		if (iteration > 1) {
			missionButtons.SetActive (true);
			resignButton.SetActive (true);

			emailLabel.sprite = reviewSprite;

			if (arguments.ContainsKey ("Kills")) {
				int kills = (int) arguments ["Kills"];
				if (kills < 200)
					emailImage.sprite = reviewContentSprite [0];
				else if (kills < 280)
					emailImage.sprite = reviewContentSprite [1];
				else
					emailImage.sprite = reviewContentSprite [2];
			}
		}

		if (iteration == 3) {
			emailLabel.sprite = badPerformanceLabel;
			emailImage.sprite = badPerformanceContent;

			resistanceEmail.gameObject.SetActive (true);
		}

		// RESIGN 
		if ((bool)arguments ["Resigned"]) {
			resignButton.GetComponent<Image> ().sprite = crossedResignSprite;
			resignButton.GetComponent<Button> ().enabled = false;
			resignLetters.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
