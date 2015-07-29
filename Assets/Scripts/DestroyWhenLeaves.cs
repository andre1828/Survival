using UnityEngine;
using System.Collections;

public class DestroyWhenLeaves : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{

		Destroy (other.gameObject);

	}
}
