using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public int PlayerLife;    //Player's life
	public GameObject[] Enemies = new GameObject[0];
	public float WaitBeforeStart;
	public float spawnWait;
	private bool KeepSpawning = true; //boolean always true to keep spawning enemies
	public Transform Player; //Pick Players position
	public GameObject GameMusic;

	//Used to respawn the Player;
	public GameObject PlayerGameobject; 
	public GameObject PlayerLight;
	private Vector3 PlayerRespawnPosition = new Vector3(0,0,0);
	private Transform target;

	
	//Variables for enemies spawn system
	public Vector3 SpawnLeft;
	public Vector3 SpawnRight;
	public Quaternion spawnRotation;
	
	void Start()
	{
		StartCoroutine (SpawnWaves ());

		//Configuration of enemies spawn system
		SpawnLeft = new Vector3 (Random.Range (-21.55f, -1f), 0, Random.Range (-18f,12.5f)); 
		SpawnRight =  new Vector3 (Random.Range (1f, 20.30f),0f,Random.Range (-18f,12.5f)); 	
		spawnRotation = Quaternion.identity;

	}

	// Update is called once per frame
	void Update () 
	{
		Pause();
		CallGameOver ();	//Check if Life reaches 0
		RespawnPlayer ();  //Check if Player is still on the scene
		KeepTrackOfPlayer ();
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

	public void CallGameOver()
	{
		if (PlayerLife == 0) //PlayerController.ReturnPlayerLife() says the how many lifes the Player has
		{
			KeepSpawning = false;				 //Stops enemies spawn
//			yield return new WaitForSeconds(1);	 //Waits seconds before calling GameOver scene
			Application.LoadLevel("GameOver");   //Call GameOver scene

		}
	}

	public void RespawnPlayer() 				//Respawns player if dies
	{
		if (!GameObject.FindGameObjectWithTag("Player")) 
		{
			DecreasePlayerLife();
			Time.timeScale = 0.5f;
			PlayerLight.SetActive(false);
//			ClearArena();
			Instantiate(PlayerGameobject,PlayerRespawnPosition,Quaternion.identity);
			StartCoroutine(WaitAfterSpawnPlayer());
			PlayerLight.transform.position = PlayerRespawnPosition;
			PlayerLight.SetActive(true);
	
		}

	}

	public IEnumerator WaitAfterSpawnPlayer()
	{
		yield return new WaitForSeconds (2);
		Time.timeScale = 1;
	}
	
	public void RandomEnemieSpawner()
	{
		if (target.position.x > 0f) {
			Instantiate (Enemies [Random.Range (0, Enemies.Length)], SpawnLeft, spawnRotation);
		} else 
		{
			Instantiate (Enemies [Random.Range (0, Enemies.Length)], SpawnRight, spawnRotation);
		}
 
	}

	public void DecreasePlayerLife()
	{
		PlayerLife--;				//Decreases Player Life
		Debug.Log (PlayerLife);
	}
	
	public int ReturnPlayerLife()   //Returns Player's Life
	{
		return PlayerLife;        
	}
	
	public void ClearArena() //encontrar um jeito de destruir inimigos na tela
	{

	}

	public void KeepTrackOfPlayer() //Keeps working everything that is looking for the Player
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
		
		if (!GameObject.FindGameObjectWithTag ("Player")) 
		{
			return;
		}
	}
}



	



