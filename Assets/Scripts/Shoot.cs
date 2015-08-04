using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject Shot; // The bullet gameobject
	private bool gunFired; //Helps limiting the fire rate
	public float FireRate; //Time to wait before player shoots;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gunFired) 
		{
			StartCoroutine (GunFire ());
		}
	}




	IEnumerator GunFire()
	{
		gunFired = true;
		Instantiate (Shot, transform.position, transform.rotation);
		yield return new WaitForSeconds(FireRate);
		gunFired = false;
	}


}
