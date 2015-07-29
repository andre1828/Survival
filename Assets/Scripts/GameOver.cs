using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	// Update is called once per frame

	void Start()
	{
		GetComponent<AudioSource>().Play ();
	}

	void Update () {

		if (Input.GetKey (KeyCode.Joystick1Button7)) 
		{
			Application.LoadLevel("MainScene");
		}
	}
}
