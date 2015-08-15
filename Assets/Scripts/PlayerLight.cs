using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	 	

	}
	
	// Update is called once per frame
	void Update () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;

		if (GameObject.FindGameObjectWithTag ("Player")) 
		{
			transform.position = new Vector3 (target.position.x, 2.34f, target.position.z);
		}
	}
}