using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{


	public GameObject StripeCube;
	public GameObject SquareCube;
	public GameObject DotsCube;
	public GameObject GridCube;
	public float WaitBeforeStart;
	public float spawnWait;
	private bool KeepSpawning = true; //boolean always true to keep spawning enemies
	public Transform Player; //Pick Players position
	public GameObject GameMusic;

	//Variables for enemies spawn system
	public Vector3 SpawnLeft;
	public Vector3 SpawnRight;
	public Quaternion spawnRotation;
	
	void Start()
	{
//		StartCoroutine (SpawnWaves ());
	}

	// Update is called once per frame
	void Update () 
	{
		Pause();
		StartCoroutine (PlayerExists ());	//Check if Player is still on the scene

		//Configuration of enemies spawn system
		SpawnLeft = new Vector3 (Random.Range (-21.55f, -1f), 0, Random.Range (-18f,12.5f)); 
		SpawnRight =  new Vector3 (Random.Range (1f, 20.30f),0f,Random.Range (-18f,12.5f)); 	
		spawnRotation = Quaternion.identity;



	}

	IEnumerator SpawnWaves ()   		  // Spawn enemies from time to time
	{

			yield return new WaitForSeconds (WaitBeforeStart);
			while (KeepSpawning == true)
			{
				RandomEnemieSpawner ();
				yield return new WaitForSeconds (spawnWait);
		
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
				GameMusic.GetComponent<AudioSource>().mute = true;
			}
			
			else if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				GameMusic.GetComponent<AudioSource>().mute = false;
			}
		}
	}
	
	IEnumerator PlayerExists()
	{
		if (!GameObject.Find ("Player"))         //If Player is not found
		{
			KeepSpawning = false;				 //Stops enemies spawn
			yield return new WaitForSeconds(1);	 //Waits seconds before calling GameOver scene
			Application.LoadLevel("GameOver");   // Call GameOver scene
			
		}
	}
	
	public void RandomEnemieSpawner()
	{
		int number = Random.Range ( 1, 5);  //Generate random number between 1 and 5 (Excluding 5)
		
		if (Player.position.x > 0f) 		//Checks if player is on the right quadrant, so it spawns enemies on the left
		{
			if (number == 1) 				//Checks the number ,each number represents a different enemie
			{
				Instantiate (StripeCube, SpawnLeft, spawnRotation);
			} else if (number == 2) {
				Instantiate (SquareCube, SpawnLeft, spawnRotation);
			} else if (number == 3) {
				Instantiate (DotsCube, SpawnLeft, spawnRotation);
			} else if (number == 4) {
				Instantiate (GridCube, SpawnLeft, spawnRotation);
			}
		}else if (Player.position.x < 0f)	//Checks if player is on the left quadrant, so it spawns enemies on the right
		{
			if(number == 1)
			{
				Instantiate(StripeCube,SpawnRight,spawnRotation);
			}else if (number == 2)
			{
				Instantiate(SquareCube,SpawnRight,spawnRotation);
			}else if (number == 3)
			{
				Instantiate(DotsCube,SpawnRight,spawnRotation);
			}else if (number == 4)
			{
				Instantiate(GridCube,SpawnRight,spawnRotation);
			}
		} 
	}
	 
}



	



