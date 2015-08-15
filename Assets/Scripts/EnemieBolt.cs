using UnityEngine;
using System.Collections;

public class EnemieBolt : MonoBehaviour {
	

	public float speed;
	private GameController gameController; //Used in the void Start to hold reference to the script attached to GameController
	public GameObject Player; // Finds Player's gameobject so it can be used in the script
	public GameObject PlayerLight;

	void Start ()
	{
		GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
		gameController = GameController.GetComponent<GameController> ();

//		Player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Destroy (gameObject, 0.5f); //Auto destroy in half second
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			gameController.DecreasePlayerLife();
			Destroy(gameObject); // Auto Destroy
			Destroy(other.gameObject); //Destroys Player
			PlayerLight.SetActive(false);
		}
	}


}