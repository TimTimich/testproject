using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour {
	public float sens= 4f;
	public float rotX;
	private float rotY;
	public GameObject eyes;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rotX = Input.GetAxis ("Mouse X") * sens;
		rotY -= Input.GetAxis ("Mouse Y") * sens;
		rotY = Mathf.Clamp (rotY, -60f, 60f);
		transform.Rotate (0, rotX, 0);
		eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
		//eyes.transform.Rotate(rotY, 0, 0);

				
	}
}
