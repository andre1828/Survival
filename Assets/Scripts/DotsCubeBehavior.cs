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

	// Use this for initialization
	void Start () {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {

		 Follow ();
	}
	void Follow () //follow the player
	{
		if (GameObject.Find ("Player") != null) 
		{
			transform.LookAt(target);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" ) 
		{
			Destroy(gameObject);  			//Auto destroy
			Destroy(other.gameObject);		//Destroys Player
		}
		if (other.tag == "Bolt")
		{
			Destroy(gameObject);  			//Auto destroy
			Destroy(other.gameObject);		

		}
	}



}
