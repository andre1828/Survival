using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject StripeCube;
	public GameObject SquareCube;
	public GameObject DotsCube;
	public GameObject GridCube;
	public float WaitBeforeStart;
	public Vector3 spawnValues;
	public float spawnWait;
	public int hazardCount;
	private bool KeepSpawning = true; //boolean always true to keep spawning enemies


	void Start()
	{
//		StartCoroutine (SpawnWaves ());
	}

	// Update is called once per frame
	void Update () 
	{
		Pause();
		PlayerExists ();	//Check if Player is still on the scene
	}

	IEnumerator SpawnWaves ()   		  // Spawn enemies from time to time
	{
	
		yield return new WaitForSeconds (WaitBeforeStart);
		while (KeepSpawning == true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				                                     spawnValues.y,
				                                     Random.Range (-spawnValues.z, spawnValues.z));  
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (DotsCube, spawnPosition, spawnRotation);
				Instantiate (GridCube, spawnPosition, spawnRotation);
				Instantiate (StripeCube, spawnPosition, spawnRotation);
				Instantiate (SquareCube, spawnPosition, spawnRotation);


				yield return new WaitForSeconds (spawnWait);
			}
		}

	}

	// Pause game
	public void Pause ()                   
	{

		if (Input.GetKeyDown (KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.P)) 
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				GetComponent<AudioSource>().Pause();
			}

			else if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				GetComponent<AudioSource>().Play();
			}
		}
	}

	public void PlayerExists()
	{
		if (!GameObject.Find ("Player"))         //If Player is not found
		{
			Application.LoadLevel("GameOver");   // Call GameOver scene
		}
	}


}

