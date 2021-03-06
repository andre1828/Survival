﻿using UnityEngine;
using System.Collections;

public class SquareCubeBehavior : MonoBehaviour {

	/*
	 * This Enemie :
	 * Follows the player
	 * Stops at a certain distance and explodes
	 */

	private Transform target;
	private float moveSpeed = 5.0f;
	private bool WillFollow = true;
	public GameObject SkillAttack;
	public GameObject energyBlast;

	//
	private InfoScript InfoScript; //Used in the void Start to hold reference to the script attached to InfoText gameobject

	// Use this for initialization
	void Start () {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;


		GameObject InfoText = GameObject.FindGameObjectWithTag("InfoText"); //Finds InfoText  gameobject
		InfoScript = InfoText.GetComponent<InfoScript> ();                 //ScoreScript receives script from InfoText gameobject
	}
	
	// Update is called once per frame
	void Update () {
		KeepTrackOfPlayer ();
		Follow ();
		ExplodeGreenCore ();
	}


	void Follow () //follows the player
	{
		if (WillFollow)
		{
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				transform.LookAt (target);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);   
			}
		}
	}

	void ExplodeGreenCore() //Explodes
	{

		float distance = Vector3.Distance (target.position, transform.position);
		
		if(distance < 3)
		{
			WillFollow = false;
			StartCoroutine(WaitBeforeExplode(0.5f, distance));

		}
		
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Bolt") {
			Destroy (gameObject);  			//Auto destroy
			InfoScript.IncreaseScore();     //Increases score
			Destroy (other.gameObject);		//Destroys Bolt
			energyBlast = (GameObject)Instantiate (energyBlast, transform.position, transform.rotation); //Instiate explosion
			Destroy (energyBlast, 1);
		}

	}

	IEnumerator WaitBeforeExplode(float Seconds, float distance)
	{
		yield return new WaitForSeconds (Seconds);
		SkillAttack = (GameObject)Instantiate(SkillAttack, transform.position, transform.rotation);
		Destroy(SkillAttack, 2);
		Destroy (gameObject);
		yield return new WaitForSeconds(Seconds);

	}

	public void KeepTrackOfPlayer()
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
		
		if (!GameObject.FindGameObjectWithTag ("Player")) 
		{
			Destroy(gameObject);
		}
	}

}
