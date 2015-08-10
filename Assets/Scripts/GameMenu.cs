using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public void PlayGame ()
	{
		Application.LoadLevel("MainScene");	//Loads the game
	}

	public void QuitGame ()					//Quits the game
	{
		Application.Quit();				    
	}

	public void LoadMainMenu ()				//Loads the MainMenu
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");  
	}
}
