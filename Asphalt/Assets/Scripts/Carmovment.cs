using UnityEngine;
using System.Collections;

public class Carmovment : MonoBehaviour {

	private float speed; //0-1
	private float rotation; // -45 to +45
	private Vector3 forward = new Vector3 (0, 0 ,-1);
	private Vector3 up = new Vector3 (0, 1, 0);
	public string RightWiimoteName = "RightWiimote";
	public string LeftWiimoteName = "LeftWiimote";

	// Use this for initialization
	void Start () {
		speed = 0f;
		rotation = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject car = GameObject.Find("Stockcar");
		car.transform.Translate(forward * Time.deltaTime *speed);
		car.transform.Rotate (up * Time.deltaTime * rotation);
		Debug.Log (forward);


		//Wii control
		if(InputBroker.GetKeyDown(RightWiimoteName + ":A")) {
			speed += 0.05f;
			Debug.Log(speed);
		}
		if(InputBroker.GetKeyDown(RightWiimoteName + ":B")) {
			if(speed >=0.5)
			speed -= 0.5f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			Debug.Log(speed);
		}

		if(InputBroker.GetKeyDown(LeftWiimoteName + ":A")) {
			rotation =30f;
		}
		if(InputBroker.GetKeyDown(LeftWiimoteName + ":B")) {
			rotation =-30f;
		}

		if(!InputBroker.GetKeyDown(LeftWiimoteName + ":A") & !InputBroker.GetKeyDown(LeftWiimoteName + ":B")) {
			rotation = 0f;
		}


		// Keyboard control
		if (Input.GetKey(KeyCode.W)){	
			speed += 0.05f;
			Debug.Log(speed);
		}
		if (Input.GetKey(KeyCode.S)){	
			if(speed >=0.5)
				speed -= 0.5f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			Debug.Log(speed);
		}
		if (Input.GetKey(KeyCode.A)){	
			rotation =-30f;
		}
		if (Input.GetKey(KeyCode.D)){	
			rotation =30f;
		}
		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			rotation =0f;		
		}

	}
}
