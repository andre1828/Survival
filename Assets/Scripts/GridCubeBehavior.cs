using UnityEngine;
using System.Collections;

public class GridCubeBehavior : MonoBehaviour {

	/*
	 * This Enemie :
	 * Follows the player
	 * Freezes the player on touch
	 * Gives 10 points when killed
	 */

	private Transform target;
	private float moveSpeed = 5.0f;
	public GameObject skillAttack2;
	public Light DirectionalLight;
	GameObject Player;
	public GameObject SnowParticles; //Particles for the Player's freezing fx
	private PlayerController playerController;

	//Score
	private InfoScript InfoScript; //Used in the void Start to hold reference to the script attached to InfoText gameobject

  	// Use this for initialization
	void Start () { 
		 GameObject InfoText = GameObject.FindGameObjectWithTag("InfoText"); //Finds InfoText  gameobject
		 InfoScript = InfoText.GetComponent<InfoScript> ();	                 //InfoScript receives script from InfoText gameobject

		 
		 Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		 playerController = Player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		KeepTrackOfPlayer ();	
		Follow ();
	}


	void Follow () //follow the player
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) 
		 {
			transform.LookAt(target);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   
		 }
	}



	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" ) 
		{
			Destroy(gameObject);  			      //Auto destroy
			playerController.CallFreezePlayer();
			skillAttack2 = (GameObject) Instantiate(skillAttack2, transform.position , transform.rotation);
			Destroy(skillAttack2,1);
		}
		if (other.tag == "Bolt")
		{
			Destroy(gameObject);  			//Auto destroy
			InfoScript.IncreaseScore(); 	//Increases score by 10
			Destroy(other.gameObject);		//Destroys Bolt
			skillAttack2 = (GameObject) Instantiate(skillAttack2, transform.position , transform.rotation);
			Destroy(skillAttack2,1);
		}
	}

	public void KeepTrackOfPlayer()
	{
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
		if (GameObject.FindGameObjectWithTag ("Player")){
			return;
		}
	}

}
