using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public void PlayGame ()
	{
		Application.LoadLevel("MainScene");
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
