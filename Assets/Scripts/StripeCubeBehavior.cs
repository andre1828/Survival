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

	// Use this for initialization
	void Start () 
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
			Follow ();
			Dash ();
	}

	void Follow () //follow the player
	{
		if (GameObject.Find ("Player") != null) 
		{
			transform.LookAt(target);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   
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

	}


}
