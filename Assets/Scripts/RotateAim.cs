using UnityEngine;
using System.Collections;

public class RotateAim : MonoBehaviour {



	void Update ()
	{
		// ROTATE A GUN OBJECT AROUND THE Z-AXIS
		// BASED ON THE ANGLE OF THE RIGHT ANALOG STICK
		float x = Input.GetAxis ("Horizontal_R") * Time.deltaTime;
		float y = Input.GetAxis ("Vertical_R") * Time.deltaTime;
//		float aim_angle = 0.0f;

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
		if (x != 0.0f || y != 0.0f) {

			//aim_angle = (Mathf.Atan2(y , x ) * Mathf.Rad2Deg) + 90;
			//Debug.Log(aim_angle);					//output to understand how to rotate the aim correctly

			// ANGLE GUN
//			transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.up );

			//this rotatese in a single diretion either left or right smoothly
			transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y + 100f * Time.deltaTime * Input.GetAxis ("Horizontal_R"),0f);
		}





	}
}
