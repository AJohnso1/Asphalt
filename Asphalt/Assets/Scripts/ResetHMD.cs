using UnityEngine;
using System.Collections;

public class ResetHMD : MonoBehaviour {

	private Vector3 HMDPosition = new Vector3(0.0f,1.8f,0.0f);
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		GameObject HMD = GameObject.Find("HMD");
		Vector3 localHMDPostion = HMD.transform.localPosition;
		if (Input.GetKey (KeyCode.R)) {
			HMD.transform.position = new Vector3(0f,0f,0f);
			Debug.Log("Yes");
		}
		
	}
}
