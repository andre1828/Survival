using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour {

	public int Score;
	string text;
	string Life; //Player's life
	private GameController gameController; //Used in the void Start to hold reference to the script attached to GameController

	public GUIStyle style = new GUIStyle();

	void Start()
	{
		GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
		gameController = GameController.GetComponent<GameController> ();     //GameController receives script from GameController gameobject
		Life = "" + gameController.ReturnPlayerLife ();
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		

		Rect rect = new Rect(0, 0, w, h -2 * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);
		text = string.Format("Score: {0} \n Life : {1}",Score, Life);
		GUI.Label(rect, text, style);

	}

	public void IncreaseScore() 
	{
		Score = Score + 10;		//Increase score by 10
	}


}
