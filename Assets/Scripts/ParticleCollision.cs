using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Destroy (other.gameObject,0.2f);

		}
		else 
		{
			return;
		}
	}
}
