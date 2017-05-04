using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private float startTime;
    [HideInInspector]
    public int restSeconds;
    private int roundedRestSeconds;
    private int displaySeconds;
    private int displayMinutes;
    private string text;

	public Font font;
	public Texture2D timerImage;

    [HideInInspector]
    public float guiTime;

    public int countDownSeconds;   // in seconds

    void Start()
    {
        GameObject controlPanel = GameObject.Find("Timer");
    }

    void Awake()
    {

        startTime = Time.time;
    }

    void Update()
    {


            guiTime = Time.time - startTime;

            restSeconds = (int)(countDownSeconds - (guiTime));


            //display the timer
            roundedRestSeconds = Mathf.CeilToInt(restSeconds);
            displaySeconds = roundedRestSeconds % 60;
            displayMinutes = roundedRestSeconds / 60;

        if (displaySeconds >= 0 || displayMinutes > 0)
        {
            text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
        }

        if (displaySeconds < 0)
        {
                displaySeconds = 0;
                text = string.Format("{0:00}:{1:00}", 0, 0);
        }

    }

    void OnGUI()
    {
        GUI.skin.box.fontStyle = FontStyle.Bold;
        GUI.skin.box.fontSize = 100;
        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.skin.font = font;
        GUI.skin.button.fontStyle = FontStyle.Bold;
        GUI.skin.button.fontSize = 100;
        GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		GUI.skin.box.normal.background = (Texture2D)timerImage;

		GUI.Box(new Rect(Screen.width / 2-200, 0, 400, 200), text);
    }
}