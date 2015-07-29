using UnityEngine;
using System.Collections;

public class TESTErotateaim : MonoBehaviour {

	public int RotationSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// ROTATE A GUN OBJECT AROUND THE Z-AXIS
		// BASED ON THE ANGLE OF THE RIGHT ANALOG STICK
		float x = Input.GetAxis ("Horizontal_R") * Time.deltaTime;
		float y = Input.GetAxis ("Vertical_R") * Time.deltaTime;



		if (x != 0.0f || y != 0.0f) {

			//this rotates in a single diretion either left or right smoothly
			transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y + 100f * RotationSpeed *Time.deltaTime * Input.GetAxis ("Horizontal_R") ,0f);
		}
	}

	}

