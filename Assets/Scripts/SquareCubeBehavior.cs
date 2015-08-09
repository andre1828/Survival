using UnityEngine;
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

	// Use this for initialization
	void Start () {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player"); // Finds Player's gameobject so it can be used in the script
		target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {

		 if (WillFollow) { Follow (); }

		 ExplodeGreenCore ();
	}


	void Follow () //follows the player
	{
		if (GameObject.Find ("Player") != null) 
		{
			transform.LookAt(target);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   
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
			Destroy (other.gameObject);		//Destroys Player
			energyBlast = (GameObject)Instantiate (energyBlast, transform.position, transform.rotation);
			Destroy (energyBlast, 1);
		}

	}

	IEnumerator WaitBeforeExplode(float Seconds, float distance)
	{
		yield return new WaitForSeconds (Seconds);
		SkillAttack = (GameObject)Instantiate(SkillAttack, transform.position, transform.rotation);
		Destroy (gameObject);
		yield return new WaitForSeconds(Seconds);
		Destroy(SkillAttack, 2);

		
	}



}
