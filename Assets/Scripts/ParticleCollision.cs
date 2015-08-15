using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour {

	private PlayerController PlayerController; //Used in the void Start to hold reference to the script attached to Player
	public GameObject Player ; // Finds Player's gameobject so it can be used in the script
	public GameObject PlayerLight;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Destroy (other.gameObject,0.2f);
			PlayerLight.SetActive(false);
		} 
		else 
		{
			return;
		}
	}
}
