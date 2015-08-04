using UnityEngine;
using System.Collections;

public class GridCubeBehavior : MonoBehaviour {

	/*
	 * This Enemie :
	 * Follows the player
	 * Freezes the player on touch
	 */

	private Transform target;
	private float moveSpeed = 5.0f;
	public GameObject skillAttack2;

	// variables to keep the distance
	public GameObject DotsCube;		
	public float Distance;

  	// Use this for initialization
	void Start () {
		 GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		 target = Player.transform;
		 
	}
	
	// Update is called once per frame
	void Update () {

		 Follow ();
//		 DontGoThrough ();	
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
			skillAttack2 = (GameObject) Instantiate(skillAttack2, transform.position , transform.rotation);
			Destroy(skillAttack2,1);
		}
		if (other.tag == "Bolt")
		{
			Destroy(gameObject);  			//Auto destroy
			Destroy(other.gameObject);		//Destroys Player
			skillAttack2 = (GameObject) Instantiate(skillAttack2, transform.position , transform.rotation);
			Destroy(skillAttack2,1);
		}
	}

	void DontGoThrough()  //trying to keep the enemies from passing through each other without using rigidbody
	{
		if (gameObject.tag != "Player") 
		{
			Distance = 3;
			transform.position = (transform.position - DotsCube.transform.position).normalized * Distance + DotsCube.transform.position;
		}
	}
}
