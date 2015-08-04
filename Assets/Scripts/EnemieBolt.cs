using UnityEngine;
using System.Collections;

public class EnemieBolt : MonoBehaviour {
	
	public float speed;
	
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Destroy (gameObject, 0.5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			Application.LoadLevel("GameOver");
		}
	}


}