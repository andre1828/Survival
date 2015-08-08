using UnityEngine;
using System.Collections;

public class RotateAim : MonoBehaviour {

	private Quaternion targetRotation;
	private Camera cam;
	Transform target;
	public float AimingSpeed;


	public GameObject Shot; // The bullet gameobject
	public Transform ShotSpawn;

	void Start()
	{
		cam = Camera.main;
//		GameObject Aim = GameObject.FindGameObjectWithTag ("Aim");
//		target = Aim.transform;

	}

	void Update ()
	{
		AimWithMouse ();
//		AimWithRightStick ();

	}

	void AimWithMouse()
	{
		// Test this piece of code looking for smooth rotation with right stick controll
		Vector3 mousePos = Input.mousePosition;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,cam.transform.position.y - transform.position.y));
		targetRotation = Quaternion.LookRotation (mousePos - new Vector3(transform.position.x,0,transform.position.z));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, AimingSpeed ) ;


	}


	void AimWithRightStick()
	{

		// ROTATE A GUN OBJECT AROUND THE Z-AXIS
		// BASED ON THE ANGLE OF THE RIGHT ANALOG STICK
//				float x = Input.GetAxis ("Horizontal_R") ;
//				float y = Input.GetAxis ("Vertical_R") ;
//				float aim_angle = 0.0f;
		
		//bool aiming_right = false;
		//bool aiming_up = false;
		
		// USED TO CHECK OUTPUT
		//Debug.Log(" horz: " + x + "   vert: " + y);
		
		
		
		
		// CANCEL ALL INPUT BELOW THIS FLOAT
		//		float R_analog_threshold = 0.20f;
		//		
		//		if (Mathf.Abs(x) < R_analog_threshold) 
		//		{
		//			x = 0.0f;
		//		} 
		//		
		//		if (Mathf.Abs(y) < R_analog_threshold)
		//		{
		//			y = 0.0f;
		//		} 
		
		
		
		// CALCULATE ANGLE AND ROTATE
		//		if (x != 0.0f || y != 0.0f) 
		//		{
		
//		aim_angle = (Mathf.Atan2(y , x ) * Mathf.Rad2Deg) + 90;
		//Debug.Log(aim_angle);					//output to understand how to rotate the aim correctly
		
		// ANGLE GUN
//					transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.up );
		
		//this rotatese in a single diretion either left or right smoothly
		//			transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y + 100f * Time.deltaTime * Input.GetAxis ("Horizontal_R"),0f);
		
		//			transform.LookAt(target);
	}
}







	





