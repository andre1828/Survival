using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
	 	target = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("Player")) 
		{
			transform.position = new Vector3 (target.position.x, transform.position.y, target.position.z);
		}
	}
}