using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {  



	public float speed;              // Player movement speed
	public GameObject Shot;          // The bullet gameobject
	public Transform ShotSpawn;      //Where the bullet will be instantiated in the scene
	private Rigidbody rb;
	private bool gunFired;           //Helps limiting the fire rate
	public float FireRate;           //Time to wait before player shoots;
	public Light DirectionalLight;   //Holds a object of type Light
	public GameObject SnowParticles; //Particles for the Player's freezing fx

	void Start()
	{
		rb = GetComponent<Rigidbody>(); //Player's Rigidbody
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
		
	IEnumerator GunFire()  //Fires Player's gun with delays
	{
		gunFired = true;
		Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
		yield return new WaitForSeconds(FireRate);
		gunFired = false;
	}

	/**this function its called from GridCubeBehavior,
	 * if we call a coroutine from other object and it gets destroyed(wich will happen), 
	 * the coroutine crashes, so we're calling a function that  intermediates the process
	 * */
	public void CallFreezePlayer() 
	{
		StartCoroutine (FreezePlayer ());
	}

	public IEnumerator FreezePlayer() 
	{
		GetComponent<AudioSource> ().Play ();
		rb.drag = 25; //Slows the Player using drag
		DirectionalLight.color = Color.blue;  //Set light color to blue
		DirectionalLight.intensity = 5;       //Fades the light changing intensity to 3
		SnowParticles.SetActive(true);		  //Activates the snow around the Player
		yield return new WaitForSeconds (5);
		ResetPlayer ();
	}

	public void ResetPlayer()
	{
		rb.drag = 0;						 //Resets the drags to 0
		DirectionalLight.color = Color.red;  //Resets the light color to red
		DirectionalLight.intensity = 8;      //Resets the light intensity (value 8)	}
	}


}



