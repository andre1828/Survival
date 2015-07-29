using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {


	public float speed; // Player movement speed
	public GameObject Shot; // The bullet gameobject
	public Transform ShotSpawn; //Where the bullet will be instantiated in the scene
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

	}
	void Update()
	
	{	//right stick deadzone  configuration
		float deadzone = 0.50f;
		Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"));
		if (stickInput.magnitude < deadzone) {
			stickInput = Vector2.zero;
		} else {
			stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
			Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
		}



	}

	void FixedUpdate()
	{

		//move player
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);

	}
}
	


