using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;
	
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Destroy (gameObject, 0.5f);
	}
}