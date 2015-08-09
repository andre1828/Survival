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
	private bool gunFired; //Helps limiting the fire rate
	public float FireRate; //Time to wait before player shoots;
	public Light DirectionalLight;  //Holds a object of type Light
	public GameObject Snowflake;
	public Transform StatusSpawn;
	public GameObject SnowParticles;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

	}
	void Update()
	
	{	
		if(Input.GetButton("Fire1") && !gunFired) //Waits mouse input to shoot
		{
			StartCoroutine(GunFire());
		}


		//right stick deadzone  configuration
//		float deadzone = 0.50f;
//		Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"));
//		if (stickInput.magnitude < deadzone) {
//			stickInput = Vector2.zero;
//		} else {
//			stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
//			Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
//		}



	}

	void FixedUpdate()
	{

		//move player
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed * Time.deltaTime);

	}
		
	IEnumerator GunFire()
	{
		gunFired = true;
		Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
		yield return new WaitForSeconds(FireRate);
		gunFired = false;
	}

	void OnTriggerEnter(Collider other) 	// just to slow Player when it hits GridCube
	{
		if (other.tag == "GridCube") 
		{
			rb.drag = 25; 					//Slows the Player using drag
			DirectionalLight.GetComponent<Light>();
			DirectionalLight.color = Color.blue; //Sets the light color to blue
			DirectionalLight.intensity = 3;      //Fades the light changing intensity to 3
			SnowParticles.SetActive(true);			 //Activates the snow around the Player
			StartCoroutine(PlayerSpeed());       //Calls PlayerSpeed to reset speed and light
		}
	}


	IEnumerator PlayerSpeed() 
	{
		ShowStatus ();
		yield return new WaitForSeconds (5); //Waits before reset Player
		rb.drag = 0;						 //Resets the drags to 0
		SnowParticles.SetActive(false);		 //Deactivates the snow around the Player
		DirectionalLight.color = Color.red;  //Resets the light color to red
		DirectionalLight.intensity = 8;      //Resets the light intensity (value 8)	}
	}

	void ShowStatus() //Show symbols depending on what happened to the Player
	{
		Snowflake = (GameObject) Instantiate(Snowflake, StatusSpawn.position, StatusSpawn.rotation); //Shows Snowflake in the scene
		Destroy (Snowflake, 1);              //Waits before destroy Snowflake symbol

	}
}



