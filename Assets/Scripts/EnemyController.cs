using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Transform target;
	private float moveSpeed = 5.0f;
	public GameObject explosion;


	// Use this for initialization
	void Start () {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {

		Rotate ();
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



	void Rotate() // rotate the enemies
	{		
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
	}

	 void OnTriggerEnter(Collider other)    //Destroy player on touch and self destructs
	{

		if (other.tag == "Player") 
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
			Application.LoadLevel("GameOver");
		}
		Destroy(other.gameObject);
		Destroy (gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
		
	}

}