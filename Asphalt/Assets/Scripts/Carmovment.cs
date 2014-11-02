using UnityEngine;
using System.Collections;

public class Carmovment : MonoBehaviour {

	private float speed; //0-1
	private float rotation; // -45 to +45
	private Vector3 forward = new Vector3 (-1, 0 ,0);
	private Vector3 up = new Vector3 (0, 1, 0);
	public string RightWiimoteName = "RightWiimote";
	public string LeftWiimoteName = "LeftWiimote";
	private Vector3 steeringWheelAxis = new Vector3(0f,1f,0f);
	private float steeringRoationAngle;

	void OnGUI() {
		GUI.Label(new Rect(100, 100, 1000, 200), speed.ToString());
	}
	
	// Use this for initialization
	void Start () {
		speed = 0f;
		rotation = 0f;
		steeringRoationAngle = 0f;

	}

	void Update () {
		carMovement();
		steeringWheelRotation();
		getRotationAngle ();
	}

	private void steeringWheelRotation(){
		GameObject steeringWheel = GameObject.Find("steeringWheel");
		steeringWheel.transform.localRotation = Quaternion.Euler(steeringWheelAxis * steeringRoationAngle);

		if (Input.GetKey(KeyCode.A) || InputBroker.GetKeyDown(LeftWiimoteName + ":A")){	
			steeringRoationAngle -= 5f;
			Debug.Log(steeringRoationAngle);
		}
		if (Input.GetKey (KeyCode.D) || InputBroker.GetKeyDown(LeftWiimoteName + ":B")) {
			steeringRoationAngle += 5f;
			Debug.Log(steeringRoationAngle);
		}

	}

	private void getRotationAngle(){
		GameObject leftwii = GameObject.Find("LeftWiimote");
		GameObject rightwii = GameObject.Find("RightWiimote");
		Vector3 leftwiiposition = leftwii.transform.position;
		Vector3 rightwiiposition = rightwii.transform.position;
		Vector3 link = rightwiiposition - leftwiiposition;
		Debug.Log ("Angle: " + angle);

	}

	private void carMovement(){
		GameObject car = GameObject.Find("carbox");
		car.transform.Translate(forward * Time.deltaTime *speed);
		car.transform.Rotate (up * Time.deltaTime *steeringRoationAngle/10);
		Debug.Log (forward);

		//Wii control
		/*
		if (InputBroker.GetKeyDown(RightWiimoteName + ":A")){	
			speed += 0.05f;
			//Debug.Log(speed);
		}
		
		if (!InputBroker.GetKeyDown(RightWiimoteName + ":A")){	
			if(speed >=0.5)
				speed -= 0.08f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			//Debug.Log(speed);
		}
		if (!InputBroker.GetKeyDown(RightWiimoteName + ":B")){	
			if(speed >=0.5)
				speed -= 0.5f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			//Debug.Log(speed);
		}
		*/
		/*
		if(InputBroker.GetKeyDown(LeftWiimoteName + ":A")) {
			rotation =30f;
			Debug.Log("Test");
		}
		if(InputBroker.GetKeyDown(LeftWiimoteName + ":B")) {
			rotation =-30f;
		}
		
		if(!InputBroker.GetKeyDown(LeftWiimoteName + ":A") & !InputBroker.GetKeyDown(LeftWiimoteName + ":B")) {
			rotation = 0f;
		}
		*/
		
		// Keyboard control

		if (Input.GetKey(KeyCode.W)){	
			speed += 0.05f;
			//Debug.Log(speed);
		}
		
		if (!Input.GetKey(KeyCode.W)){	
			if(speed >=0.5)
				speed -= 0.08f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			//Debug.Log(speed);
		}
		if (Input.GetKey(KeyCode.S)){	
			if(speed >=0.5)
				speed -= 0.5f;
			if (speed > 0 && speed < 0.5)
				speed = 0;
			//Debug.Log(speed);
		}
	}
}
