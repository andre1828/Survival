using UnityEngine;
using System.Collections;

public class DotsCubeBehavior : MonoBehaviour {

	/*
	 * This Enemie : 
	 * -Follows the player
	 * -Shoots the player
	 */

	private Transform target;
	private float moveSpeed = 5.0f;
	public GameObject frameBall;
	public GameObject Player; 
	public GameObject PlayerLight;


	private GameController gameController; //Used in the void Start to hold reference to the script attached to GameController

	//Info in the screen (Score and lifes)
	private InfoScript InfoScript; //Used in the void Start to hold reference to the script attached to InfoText gameobject

	// Use this for initialization
	void Start () {

		GameObject GameController = GameObject.FindGameObjectWithTag ("GameController");
		gameController = GameController.GetComponent<GameController> ();   //GameController receives script from GameController gameobject			

		GameObject InfoText = GameObject.FindGameObjectWithTag("InfoText"); //Finds InfoText  gameobject
		InfoScript = InfoText.GetComponent<InfoScript> ();				  //InfoScript receives script from InfoText gameobject
	}
	
	// Update is called once per frame
	void Update () {
		 KeepTrackOfPlayer ();	
		 Debug.Log (target);
		 Follow ();
	}

	public void Follow () //follow the player
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);   
		} 
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" ) 
		{
			Destroy(gameObject);  			//Auto destroy
			Destroy(other.gameObject);		//Destroys Player
			PlayerLight.SetActive(false);
			gameController.DecreasePlayerLife();//Decreases Player's Life
		}
		if (other.tag == "Bolt")
		{
			Destroy(gameObject);  			//Auto destroy
			InfoScript.IncreaseScore();     //Increases Score
			Destroy(other.gameObject);	
			frameBall = (GameObject)Instantiate(frameBall, transform.position, transform.rotation );
			Destroy(frameBall,1);
		}
	}

	public void KeepTrackOfPlayer()
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
	}

}
