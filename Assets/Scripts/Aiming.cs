using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {
	private Quaternion targetRotation;
	private Camera cam;
	public float AimingSpeed;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//AimMovement ();  //Aim with right analog on controll
		ControlMouse ();   //Aim with mouse	

	}

	void AimMovement()
	{

		//Aim movement with right stick controll
		float moveHorizontal = Input.GetAxis ("Horizontal_R");
		float moveVertical = Input.GetAxis ("Vertical_R");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, -moveVertical);
		
		
		//Deadzone configuration
		float deadzone = 0.50f;				
		Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"));
		if (stickInput.magnitude < deadzone) {
			stickInput = Vector2.zero;
		} else {
			stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
			transform.Translate (movement * Time.deltaTime * AimingSpeed);
		}

	}



	void ControlMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,cam.transform.position.y - transform.position.y));
		targetRotation = Quaternion.LookRotation (mousePos - new Vector3(transform.position.x,0,transform.position.z));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, AimingSpeed ) ;
	}

}

