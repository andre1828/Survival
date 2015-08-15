using UnityEngine;
using System.Collections;

public class StripeCubeBehavior : MonoBehaviour {

	/*
	 * -This Enemie : 
	 * -follows the player 
	 * -Runs in Player's direction when close
	 */


	private Transform target; 		// Store Player's Tranform so it can be followed 
	private float moveSpeed = 5.0f; //Speed to follow the Player
	public GameObject Spark; 		// animation to be played when StripeCube dashes
	public GameObject Player ; 
	public GameObject PlayersLight;

	//Score
	private InfoScript InfoScript; //Used in the void Start to hold reference to the script attached to InfoText gameobject

	// Use this for initialization
	void Start () 
	{
		target = Player.transform;

		GameObject InfoText = GameObject.FindGameObjectWithTag("InfoText"); //Finds ScoreText  gameobject
		InfoScript = InfoText.GetComponent<InfoScript> ();				   //InfoScript receives script from InfoText gameobject
	}
	
	// Update is called once per frame
	void Update () 
	{
		KeepTrackOfPlayer ();
		StartCoroutine(Follow ());
		Dash ();
				
	}

	IEnumerator Follow () //follow the player
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);   
		} else {
			Debug.Log("nopes");
			yield return new WaitForSeconds(1);
		}
	}

	void Dash() //this is supposed to be int the StripeCubeBehavior script
	{
		float distance = Vector3.Distance (target.position, transform.position);

		if (distance < 3)
		{
			moveSpeed = moveSpeed * 1.5f; 
			Spark = (GameObject) Instantiate(Spark, transform.position, transform.rotation);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" ) 
		{
			Destroy(gameObject);  			//Auto destroy
			Destroy(other.gameObject);      //Destroys Player
			PlayersLight.SetActive(false);  //Turns  off Player light
			Spark = (GameObject) Instantiate(Spark, transform.position, transform.rotation);
			Destroy(Spark, 1);
		}
		if (other.tag == "Bolt")
		{
			Destroy(gameObject);  			//Auto destroy
			InfoScript.IncreaseScore();     //Increases score
			Destroy(other.gameObject);		//Destroys Bolt
			Spark = (GameObject) Instantiate(Spark, transform.position, transform.rotation);
			Destroy(Spark, 1);

		}
	}

	public void KeepTrackOfPlayer()
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
	}

}
